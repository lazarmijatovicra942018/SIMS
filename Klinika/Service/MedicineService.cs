using klinika.Model;
using Klinika.Controller;
using Klinika.Model;
using Klinika.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace Klinika.Service
{
    public class MedicineService
    {

        private readonly MedicineRepository _MedicineRepo;
        private static UserService _userService;
        private static ComponentService _componentService;




        private List<Medicine> medicinesWithAddingDate = new List<Medicine>();




        public MedicineService(MedicineRepository medicineRepository,UserService userService, ComponentService componentService)
        {
            _MedicineRepo = medicineRepository;
            _userService = userService;
            _componentService = componentService;
            LoadMedicinesWithDatesInList();
              InitilaizeTimer();
              timer.Start();


        }



        public List<Medicine> GetAllMedication() => _MedicineRepo.GetAll();

        public Medicine GetMedicineById(string id) => _MedicineRepo.GetById(id);


        public void SaveNewMedicine(Medicine medicine) => _MedicineRepo.SaveNewItem(medicine);

        public void DeleteMedicin(Medicine medicine) => _MedicineRepo.Delete(medicine);


        public ObservableCollection<Medicine> PutListInObservableCollection(List<Medicine> medicines) => _MedicineRepo.PutListInObservableCollection(medicines);

        public List<Medicine> GetAllMedicationWaitingForApproval()
        {
            List<Medicine> medicationWaitingForApproval = new List<Medicine>();
            List<Medicine> medicineList = GetAllMedication();
            foreach (Medicine medicine in medicineList)
            {
                if (medicine.isApproved == false && medicine.isDeclined == false) { medicationWaitingForApproval.Add(medicine); }


            }

            return medicationWaitingForApproval;
        }






        #region Sort

        public List<Medicine> MedicineListSorter(int sortChoise, List<Medicine> medicineList)
        {

            if (sortChoise == 0)
            {
                medicineList.Sort((a, b) => a.name.CompareTo(b.name));
            }
            else if (sortChoise == 1)
            {
                medicineList.Sort((a, b) => a.price.CompareTo(b.price));
            }
            else if (sortChoise == 2)
            {

                medicineList.Sort((a, b) => a.quantity.CompareTo(b.quantity));

            }


            return medicineList;
        }

        #endregion

        #region Search
        public ObservableCollection<Medicine> SearchBy(int searchableitem, List<Medicine> medicineList, string searchBoxText)
        {
            searchBoxText = RemoveWhiteSpacesAndBrackets(searchBoxText);

            IEnumerable<Medicine> medicineiIEnumerable = medicineList;
            if (searchableitem == 1)
            {

                medicineiIEnumerable = medicineList.Where(x => x.id.ToLower().Contains(searchBoxText.ToLower()));
            }
            else if (searchableitem == 2)
            {
                medicineiIEnumerable = medicineList.Where(x => x.name.ToLower().Contains(searchBoxText.ToLower()));
            }
            else
            if (searchableitem == 3)
            {
                medicineiIEnumerable = medicineList.Where(x => x.manufactur.ToLower().Contains(searchBoxText.ToLower()));
            }
            else if (searchableitem == 4)
            {
                medicineiIEnumerable = medicineList.Where(x => x.quantity.ToString().Contains(searchBoxText.ToLower()));
            }
            else if (searchableitem == 5)
            {

                medicineiIEnumerable = SearchByComponents(medicineList, searchBoxText);
            }

            return new ObservableCollection<Medicine>(medicineiIEnumerable);



        }

        #region SearchByComponents

        public List<Medicine> SearchByComponents(List<Medicine> medicineList, string searchBoxText)
        {

            List<Medicine> returnMedicines;


            searchBoxText = RemoveWhiteSpacesAndBrackets(searchBoxText);

            returnMedicines = SeparateByAndOperator(searchBoxText, medicineList);



            return returnMedicines;



        }



        public List<Medicine> SeparateByAndOperator(string stringWithAndOperator, List<Medicine> medicineList)
        {
            List<Medicine> returnMedicines = new List<Medicine>(medicineList);
            List<Medicine> medicinesAnd = new List<Medicine>();


            foreach (string stringWithOrOperands in stringWithAndOperator.Split('&'))
            {
                if (stringWithOrOperands.Contains("|"))
                {

                    medicinesAnd.AddRange(SeparateByOrOperator(stringWithOrOperands, medicineList));

                }
                else
                {
                    if (stringWithOrOperands.Equals(""))
                    {
                        continue;
                    }
                    else
                    {

                        medicinesAnd.AddRange(GetMedicinesWIthComponents(medicineList, stringWithOrOperands));
                    }

                }


                returnMedicines = Intersect(returnMedicines, medicinesAnd);
                medicinesAnd.Clear();
            }



            return returnMedicines.Distinct().ToList();
        }


        public List<Medicine> SeparateByOrOperator(string stringWithOrOperator, List<Medicine> medicineList)
        {
            List<Medicine> returnMedicine = new List<Medicine>();

            foreach (string splitedString in stringWithOrOperator.Split('|'))
            {
                if (splitedString.Equals(""))
                {
                    continue;
                }
                else
                {
                    returnMedicine.AddRange(GetMedicinesWIthComponents(medicineList, splitedString));

                }

            }

            return returnMedicine;

        }


        public string RemoveWhiteSpacesAndBrackets(string stringWithWhiteSpscesAndBrackets)
        {
            stringWithWhiteSpscesAndBrackets = stringWithWhiteSpscesAndBrackets.Replace(")", "");
            stringWithWhiteSpscesAndBrackets = stringWithWhiteSpscesAndBrackets.Replace("(", "");
            stringWithWhiteSpscesAndBrackets = RemoveWhiteSpaces(stringWithWhiteSpscesAndBrackets);

            return stringWithWhiteSpscesAndBrackets;
        }


        public string RemoveWhiteSpaces(string stringWithWhiteSpaces) => stringWithWhiteSpaces.Replace(" ", "");



        public List<Medicine> GetMedicinesWIthComponents(List<Medicine> medicineList, string delimiteredText)
        {
            List<Medicine> returnMedicine = new List<Medicine>();
            foreach (Medicine medicine in medicineList)
            {


                if (CheckIfMedicineContainsComponent(medicine, delimiteredText))
                {

                    returnMedicine.Add(medicine);
                }


            }

            return returnMedicine;
        }

        public List<Medicine> Intersect(List<Medicine> list1, List<Medicine> list2)
        {
            List<Medicine> returnList = new List<Medicine>();

            foreach (Medicine medicine in list1)
            {
                if (list2.Contains(medicine))
                {
                    returnList.Add(medicine);
                }

            }



            return returnList;
        }


        public bool CheckIfMedicineContainsComponent(Medicine medicine, string delimiteredText)
        {
            foreach (String component in medicine.components.Keys)
            {

                if (component.ToLower().Contains(delimiteredText.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region SearchByPrice


        public ObservableCollection<Medicine> SearchByPrice(List<Medicine> medicineList, string minP, string maxP)
        {

            Double maxPrice = ParseMaxToDouble(maxP);
            Double minPrice = ParseMinToDouble(minP);

            List<Medicine> returnMedicines = MedicinesPriceRangeCheck(medicineList, maxPrice, minPrice);

            return new ObservableCollection<Medicine>(returnMedicines);




        }


        public List<Medicine> MedicinesPriceRangeCheck(List<Medicine> medicineList, Double maxPrice, Double minPrice)
        {
            List<Medicine> returnMedicines = new List<Medicine>(medicineList);
            foreach (Medicine medicine in medicineList)
            {
                if (!(medicine.price >= minPrice && medicine.price <= maxPrice))
                {
                    returnMedicines.Remove(medicine);
                }
            }

            return returnMedicines;

        }

        public Double ParseMinToDouble(string minPrice)
        {
            if (string.IsNullOrEmpty(minPrice))
            {
                return Double.MinValue;
            }
            else { return Double.Parse(minPrice); }


        }

        public Double ParseMaxToDouble(string maxPrice)
        {
            if (string.IsNullOrEmpty(maxPrice))
            {
                return Double.MaxValue;
            }
            else { return Double.Parse(maxPrice); }



        }
        #endregion


        #endregion

        #region MedicineApproval

        public void MedicineApproval(Medicine medicineForApproval)
        {


            AddUserToAprovalList(medicineForApproval);

            CheckIfMedicineCanBeApproved(medicineForApproval);


        }



        public void AddUserToAprovalList(Medicine medicineForApproval)
        {
            User activeUser = _userService.ActiveUser;
            if (!medicineForApproval.ApprovedByUsers.Contains(activeUser))
            {
                medicineForApproval.ApprovedByUsers.Add(activeUser);

            }
        }


        public void CheckIfMedicineCanBeApproved(Medicine medicineForApproval)
        {
            int farmaceuti = 0;
            int doktor = 0;


            foreach (User user in medicineForApproval.ApprovedByUsers ?? new List<User>())
            {
                if (user.userType == klinika.Enum.UserType.Pharmacist) { farmaceuti++; }
                if (user.userType == klinika.Enum.UserType.Doctor) { doktor++; }


            }


            if (doktor > 1 && farmaceuti > 0)
            {


                medicineForApproval.isApproved = true;
            }
        }

        #endregion

        #region MedicineDecline
        public void MedicineDecline(Medicine medicineForDecline, User activeUser, string description)
        {

            medicineForDecline.isDeclined = true;
            medicineForDecline.DeclineDescription = description;
            medicineForDecline.DeclinedByUsers = activeUser;

        }
        #endregion

        public void SaveMedicines(List<Medicine> partialMedicalList)
        {

            foreach (Medicine medicine in GetAllMedication())
            {
                if (!partialMedicalList.Contains(medicine))
                {
                    partialMedicalList.Add(medicine);
                }

            }


            _MedicineRepo.Serialize(partialMedicalList);

        }


        public void SaveChangedMedicine(Medicine changedMedicine)
        {
            List<Medicine> medicineList = GetAllMedication();
            foreach (Medicine medicine in medicineList.ToList())
            {
                if (changedMedicine.id == medicine.id)
                {
                    medicineList.Remove(medicine);

                }
            }


            medicineList.Add(changedMedicine);

            _MedicineRepo.Serialize(medicineList);

        }


        #region GetAllMedicineInObservableCollection


        public ObservableCollection<Medicine> GetObservableListApprovalPending(ObservableCollection<Medicine> medicines)
        {

            ObservableCollection<Medicine> clonedMedicinesCollection = new ObservableCollection<Medicine>(medicines);


            foreach (Medicine medicine in clonedMedicinesCollection)
            {
                if (medicine.isApproved || medicine.isDeclined)
                {
                    medicines.Remove(medicine);
                }

            }


            return medicines;
        }
        public ObservableCollection<Medicine> GetAllApprovedAndDeclinedMedicines()
        {
            ObservableCollection<Medicine> allMedicines = new ObservableCollection<Medicine>();
            allMedicines = _MedicineRepo.PutListInObservableCollection(GetAllMedication());
            ObservableCollection<Medicine> approvedAndDeckinedMedicines = new ObservableCollection<Medicine>();


            foreach (Medicine medicine in allMedicines)
            {
                if (medicine.isDeclined || medicine.isApproved)
                {
                    approvedAndDeckinedMedicines.Add(medicine);
                }

            }


            return approvedAndDeckinedMedicines;



        }


        public ObservableCollection<Medicine> GetAllApprovedMedicines()
        {
            ObservableCollection<Medicine> allMedicines = new ObservableCollection<Medicine>();
            allMedicines = _MedicineRepo.PutListInObservableCollection(GetAllMedication());
            ObservableCollection<Medicine> approvedMedicines = new ObservableCollection<Medicine>();


            foreach (Medicine medicine in allMedicines)
            {
                if (medicine.isApproved)
                {
                    approvedMedicines.Add(medicine);
                }

            }




            return approvedMedicines;


        }


        public ObservableCollection<Medicine> GetAllADeclinedMedicines()
        {
            ObservableCollection<Medicine> allMedicines = new ObservableCollection<Medicine>();
            allMedicines = _MedicineRepo.PutListInObservableCollection(GetAllMedication());
            ObservableCollection<Medicine> decklinedMedicines = new ObservableCollection<Medicine>();


            foreach (Medicine medicine in allMedicines)
            {
                if (medicine.isDeclined)
                {
                    decklinedMedicines.Add(medicine);
                }

            }




            return decklinedMedicines;

        }

        #endregion

        public void AddQuantity(Medicine selectedMedicine, int quantity)
        {



            List<Medicine> medicineList = GetAllMedication();
            Medicine medicineForAdition = FindMedicineById(medicineList, selectedMedicine.id);
            medicineForAdition.quantity = quantity + medicineForAdition.quantity;
            _MedicineRepo.Serialize(medicineList);

        }

        private DispatcherTimer timer = new DispatcherTimer();


        public void AddQuantityWithTime(Medicine selectedMedicine, int quantity, DateTime timeForAdding)
        {


            selectedMedicine.quantityForAdding = quantity;
            selectedMedicine.dateForAddingQuantities = timeForAdding;
            SaveChangedMedicine(selectedMedicine);
            LoadMedicinesWithDatesInList();


        }




        private void InitilaizeTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(60);
            timer.Tick += timer_Tict;

        }

        private void timer_Tict(object? sender, EventArgs e)
        {
            foreach (Medicine medicine in medicinesWithAddingDate)
            {
                if (medicine.dateForAddingQuantities < DateTime.Now)
                {
                    int quantity = medicine.quantityForAdding;
                    medicine.dateForAddingQuantities = new DateTime();


                    AddQuantity(medicine, quantity);

                }
            }

        }

        public void LoadMedicinesWithDatesInList()
        {
            List<Medicine> medicationWithDates = GetAllMedication();
            foreach (Medicine medicine in medicationWithDates)
            {
                if (medicine.dateForAddingQuantities != new DateTime()) { medicinesWithAddingDate.Add(medicine); };

            }

        }



        private Medicine FindMedicineById(List<Medicine> medicineList, string id)
        {
            foreach (Medicine medicine in medicineList)
            {
                if (medicine.id == id) { return medicine; }
            }
            return null;
        }

        public void AddNewMedicine(string id, string name, string manufactur, ObservableCollection<Component> componentsOb, int quantity, double price)
        {
              IDictionary<string, Component>  components = _componentService.ConvertObservableCollectionToIDictionary(componentsOb);
              Medicine medicine = new Medicine(id, name, manufactur, components, quantity, price);
              SaveChangedMedicine(medicine);
        }
    }

}
