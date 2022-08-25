using klinika.Model;
using Klinika.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Klinika.Service
{
    public class MedicineService
    {

        private readonly MedicineRepository _MedicineRepo;
      

        public MedicineService(MedicineRepository medicineRepository)
        {
            _MedicineRepo = medicineRepository;


        }

        public List<Medicine> GetAllMedication() => _MedicineRepo.GetAll();

        public Medicine GetMedicineById(string id) => _MedicineRepo.GetById(id);

        
        public void SaveNewMedicine(Medicine medicine) => _MedicineRepo.SaveNewItem(medicine);

        public void DeleteMedicin(Medicine medicine) => _MedicineRepo.Delete(medicine);


        public ObservableCollection<Medicine> PutListInObservableCollection(List<Medicine> medicines) => _MedicineRepo.PutListInObservableCollection(medicines);

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


            //      searchBoxText = searchBoxText.Replace("(", string.Empty);
            //    searchBoxText =  searchBoxText.Replace(")", string.Empty);

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

            

    }
}
