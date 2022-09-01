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
        private DispatcherTimer timer = new DispatcherTimer();




        private List<Medicine> medicinesWithAddingDate = new List<Medicine>();

        public MedicineService(MedicineRepository medicineRepository, UserService userService, ComponentService componentService)
        {
            _MedicineRepo = medicineRepository;
            _userService = userService;
            _componentService = componentService;
            LoadMedicinesWithDatesInList();
            InitilaizeTimer();
            timer.Start();


        }


        public Medicine GetMedicineById(string id) => _MedicineRepo.GetById(id);

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
    
        #region GetAllMedicineInObservableCollection


        public ObservableCollection<Medicine> GetMedicinesApprovalPending()
        {

            List<Medicine> medicineList = _MedicineRepo.GetAll();
            List<Medicine> medicinesApprovalPending = new List<Medicine>(medicineList);


            foreach (Medicine medicine in medicineList)
            {
                if (medicine.isApproved || medicine.isDeclined)
                {
                    medicinesApprovalPending.Remove(medicine);
                }
            }
            return new ObservableCollection<Medicine>(medicinesApprovalPending);
        }

        public ObservableCollection<Medicine> GetAllApprovedAndDeclinedMedicines()
        {
            List<Medicine> allMedicines = _MedicineRepo.GetAll();
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
            List<Medicine> allMedicines = _MedicineRepo.GetAll();
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
            List<Medicine> allMedicines = _MedicineRepo.GetAll();
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

        #region AddQuantity
        public void AddQuantity(Medicine selectedMedicine, int quantity)
        {
            selectedMedicine.quantity = quantity + selectedMedicine.quantity;
            _MedicineRepo.SaveChangedMedicine(selectedMedicine);
        }
            
        

        public void AddQuantityWithTime(Medicine selectedMedicine, int quantity, DateTime timeForAdding)
        {
            selectedMedicine.quantityForAdding = quantity;
            selectedMedicine.dateForAddingQuantities = timeForAdding;
            _MedicineRepo.SaveChangedMedicine(selectedMedicine);
            LoadMedicinesWithDatesInList();
        }

        public void LoadMedicinesWithDatesInList()
        {
            List<Medicine> medicationWithDates = _MedicineRepo.GetAll();
            medicinesWithAddingDate = new List<Medicine>();
            foreach (Medicine medicine in medicationWithDates)
            {
                if (medicine.dateForAddingQuantities != new DateTime()) { medicinesWithAddingDate.Add(medicine); };
            }
        }

        #region Timer

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
                    medicine.dateForAddingQuantities = new DateTime();
                    AddQuantity(medicine, medicine.quantityForAdding);

                }
            }
        }

        #endregion

        #endregion

        #region AddNewMedicine
        public void AddNewMedicine(string id, string name, string manufactur, ObservableCollection<Component> componentsOb, int quantity, double price)
        {
            IDictionary<string, Component> components = _componentService.ConvertObservableCollectionToIDictionary(componentsOb);
            Medicine medicine = new Medicine(id, name, manufactur, components, quantity, price);
            _MedicineRepo.SaveNewItem(medicine);

        }

        #endregion

        #region MedicineApproval

        public void MedicineApproval(Medicine medicineForApproval)
        {


            medicineForApproval = AddUserToAprovalList(medicineForApproval);

            medicineForApproval = CheckIfMedicineCanBeApproved(medicineForApproval);

            _MedicineRepo.SaveChangedMedicine(medicineForApproval);


        }



        public Medicine AddUserToAprovalList(Medicine medicineForApproval)
        {
            User activeUser = _userService.ActiveUser;
            if (!medicineForApproval.ApprovedByUsers.Contains(activeUser))
            {
                medicineForApproval.ApprovedByUsers.Add(activeUser);

            }

            return medicineForApproval;
        }


        public Medicine CheckIfMedicineCanBeApproved(Medicine medicineForApproval)
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

            return medicineForApproval;
        }

        #endregion

        #region MedicineDecline

        public void MedicineDecline(Medicine medicineForDecline, string description)
        {
            medicineForDecline.isDeclined = true;
            medicineForDecline.DeclineDescription = description;
            medicineForDecline.DeclinedByUsers = _userService.ActiveUser;
            _MedicineRepo.SaveChangedMedicine(medicineForDecline);

        }


        #endregion

    }

}