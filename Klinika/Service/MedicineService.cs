using klinika.Model;
using Klinika.Controller;
using Klinika.Model;
using Klinika.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Klinika.Service
{
    public class MedicineService
    {

        private readonly MedicineRepository _MedicineRepo;

        private UserController _userController;

        



        public MedicineService(MedicineRepository medicineRepository)
        {
            _MedicineRepo = medicineRepository;
            var app = Application.Current as App;
            _userController = app.UserController?? new UserController(new UserService(new UserRepository()));

        }

        public List<Medicine> GetAllMedication() => _MedicineRepo.GetAll();

        public Medicine GetMedicineById(string id) => _MedicineRepo.GetById(id);

        
        public void SaveNewMedicine(Medicine medicine) => _MedicineRepo.SaveNewItem(medicine);

        public void DeleteMedicin(Medicine medicine) => _MedicineRepo.Delete(medicine);


        public ObservableCollection<Medicine> PutListInObservableCollection(List<Medicine> medicines) => _MedicineRepo.PutListInObservableCollection(medicines);
       
        public List<Medicine> GetAllMedicationWaitingForApproval()
        {
            List<Medicine> medicationWaitingForApproval = new List<Medicine>();
            foreach(Medicine medicine in GetAllMedication())
            {
                if (medicine.isApproved== false &&  medicine.isDeclined == false) { medicationWaitingForApproval.Add(medicine);}


            }

            return medicationWaitingForApproval;
        }



        public List<Medicine> GetAllApprovedMedication()
        {
            List<Medicine> approvedmedication = new List<Medicine>();
            foreach (Medicine medicine in GetAllMedication())
            {
                if (medicine.isApproved  ) { approvedmedication.Add(medicine); }


            }

            return approvedmedication;
        }





        public  List<Medicine> MedicineListSorter(int sortChoise , List<Medicine> medicineList)
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


        public IEnumerable<Medicine> SearchBy(int searchableitem,List<Medicine> medicineList, string searchBoxText)
        {
            if (searchableitem == 1)
            {
                return medicineList.Where(x => x.id.ToLower().Contains(searchBoxText.ToLower()));
            }
            else if (searchableitem == 2)
            {
                return medicineList.Where(x => x.name.ToLower().Contains(searchBoxText.ToLower()));
            }
            else
            if (searchableitem == 3)
            {
                return medicineList.Where(x => x.manufactur.ToLower().Contains(searchBoxText.ToLower()));
            }
            else if (searchableitem == 4)
            {
                return medicineList.Where(x => x.quantity.ToString().Contains(searchBoxText.ToLower()));
            }
            else if (searchableitem == 5)
            {


                return (IEnumerable<Medicine>)SearchByComponents(medicineList, searchBoxText);
            }
            else 



              return medicineList;
        }


        public IEnumerable<Medicine> SearchByComponents(List<Medicine> medicineL , string searchBoxText)
        {
            List<Medicine> MedicinesDivided = new List<Medicine>();
         


            List<Medicine> returnMedicines = new List<Medicine>(medicineL);
            List<Medicine> medicineList = new List<Medicine>(medicineL);


           

            foreach (string searchComponents in searchBoxText.Split('&'))
             {
                 if (searchComponents.Contains("|"))
                 {
                    foreach (string searchComponentWithOr in searchComponents.Split('|'))
                    {
                        if (searchComponentWithOr.Trim().Equals(""))
                        {
                        }
                        else
                        {
                            MedicinesDivided.AddRange(GetMedicinesWIthComponents(medicineList, searchComponentWithOr.Trim().Trim('(',')')));

                        }

                    }


                     MedicinesDivided = MedicinesDivided.Distinct().ToList();


                 }
                 else
                 {
                    if (searchComponents.Trim().Equals(""))
                    {
                        continue;
                    }
                    else
                    {

                        MedicinesDivided.AddRange(GetMedicinesWIthComponents(medicineList, searchComponents.Trim().Trim('(', ')')));
                    }

                 }

                 
                returnMedicines = Intersect(returnMedicines, MedicinesDivided);
                MedicinesDivided.Clear();                
               
             }



            returnMedicines = returnMedicines.Distinct().ToList();
            return returnMedicines;

        }


        public List<Medicine> GetMedicinesWIthComponents(List<Medicine> medicineList, string delimiteredText)
        {
            List<Medicine> returnMedicine = new List<Medicine>();
            foreach(Medicine medicine in medicineList)
            {
                foreach(String component in medicine.components.Keys)

                    if (component.ToLower().Contains(delimiteredText.ToLower()))
                    {
                        
                        returnMedicine.Add(medicine);
                    } 
                

            }

            returnMedicine = returnMedicine.Distinct().ToList();

            return returnMedicine;
        }

        public List<Medicine> Intersect(List<Medicine> list1 ,List<Medicine> list2)
        {
            List<Medicine> returnList = new List<Medicine>();

            foreach(Medicine medicine in list1)
            {
                if (list2.Contains(medicine))
                {
                    returnList.Add(medicine);
                }

            }



            return returnList;
        }



        public List<Medicine> SearchByPrice( List<Medicine> medicineList, string minP , string maxP)
        {
            Double maxPrice;
            Double minPrice;
            if (string.IsNullOrEmpty(maxP)) {
                maxPrice = int.MaxValue;
            }
            else { maxPrice = Double.Parse(maxP); }

            if (string.IsNullOrEmpty(minP))
            {
                minPrice = int.MinValue;
            }
            else { minPrice = Double.Parse(minP); }

            List<Medicine> returnMedicines = new List<Medicine>();

            foreach( Medicine medicine in medicineList)
            {
                if(medicine.price >= minPrice && medicine.price <= maxPrice)
                {
                    returnMedicines.Add(medicine);
                }
            }




            return returnMedicines;
        }

        
        public  ObservableCollection<Medicine> GetObservableListApprovalPending(ObservableCollection<Medicine> medicines)
        {

            ObservableCollection<Medicine> clonedMedicinesCollection = new ObservableCollection<Medicine>(medicines);


            foreach ( Medicine medicine in clonedMedicinesCollection)
            {
                if (medicine.isApproved || medicine.isDeclined)
                {
                    medicines.Remove(medicine);
                }

            }


            return medicines;
        }




        public void MedicineApproval(Medicine medicineForApproval , User activeUser)
        {
            int farmaceuti = 0;
            int doktor = 0;

            if (!medicineForApproval.ApprovedByUsers.Contains(activeUser)){
                medicineForApproval.ApprovedByUsers.Add(activeUser);

            }

            foreach (User user in medicineForApproval.ApprovedByUsers ?? new List<User>())
            {
                if (user.userType == klinika.Enum.UserType.Pharmacist) { farmaceuti++; }
                if (user.userType == klinika.Enum.UserType.Doctor) { doktor++; }


            }


               if (doktor > 1 && farmaceuti >0) {
                
              
                medicineForApproval.isApproved = true; }


        }



        public void MedicineDecline(Medicine medicineForDecline , User activeUser , string description)
        {
            
            medicineForDecline.isDeclined = true;
            medicineForDecline.DeclineDescription = description;
            medicineForDecline.DeclinedByUsers = activeUser;

        }


        public void SaveMedicines(List<Medicine> partialMedicalList)
        {

            foreach(Medicine medicine in GetAllMedication())
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
            Medicine medicineInFile;
            List<Medicine> medicineList = GetAllMedication();
            foreach(Medicine medicine in medicineList.ToList())
            {
                if(changedMedicine.id == medicine.id)
                {
                    medicineList.Remove(medicine);
                }
            }

            
            medicineList.Add(changedMedicine);

            _MedicineRepo.Serialize(medicineList);

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
                    if (medicine.isDeclined )
                    {
                        decklinedMedicines.Add(medicine);
                    }

                }




                return decklinedMedicines;



    }



    

    }

}
