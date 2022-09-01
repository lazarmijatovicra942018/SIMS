using klinika.Model;
using Klinika.Model;
using Klinika.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Klinika.Controller
{
    public class MedicineController
    {

        private readonly MedicineService _MedicineService;

        public MedicineController(MedicineService medicineService)
        {
            _MedicineService = medicineService;
        }

        public Medicine GetMedicineById(string id) => _MedicineService.GetMedicineById(id);
        public List<Medicine> MedicineListSorter(int sortChoise, List<Medicine> medicineList) => _MedicineService.MedicineListSorter(sortChoise, medicineList);

        public ObservableCollection<Medicine> SearchBy(int searchableitem, List<Medicine> medicineList, string searchBoxText) => _MedicineService.SearchBy(searchableitem, medicineList, searchBoxText);

        public ObservableCollection<Medicine> SearchByPrice(List<Medicine> medicineList, string minPrice, string maxPrice) => _MedicineService.SearchByPrice(medicineList, minPrice, maxPrice);

        public ObservableCollection<Medicine> GetMedicinesApprovalPending() => _MedicineService.GetMedicinesApprovalPending();

        public void MedicineApproval(Medicine medicineForApproval) => _MedicineService.MedicineApproval(medicineForApproval);

        public void MedicineDecline(Medicine medicineForDecline, string description) => _MedicineService.MedicineDecline(medicineForDecline, description);

        public ObservableCollection<Medicine> GetAllApprovedAndDeclinedMedicines() => _MedicineService.GetAllApprovedAndDeclinedMedicines();

        public ObservableCollection<Medicine> GetAllApprovedMedicines() => _MedicineService.GetAllApprovedMedicines();

        public ObservableCollection<Medicine> GetAllADeclinedMedicines() => _MedicineService.GetAllADeclinedMedicines();

        public void AddQuantity(Medicine selectedMedicine, int quantity) => _MedicineService.AddQuantity(selectedMedicine, quantity);

        public void AddQuantityWithTime(Medicine selectedMedicine, int quantity, DateTime timeInterval) => _MedicineService.AddQuantityWithTime(selectedMedicine, quantity, timeInterval);

        public void AddNewMedicine(string id, string name, string manufactur, ObservableCollection<Component> componentsOb, int quantity, double price) => _MedicineService.AddNewMedicine(id, name, manufactur, componentsOb, quantity, price);


    }


}

