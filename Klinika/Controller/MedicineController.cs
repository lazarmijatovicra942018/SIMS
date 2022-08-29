using klinika.Model;
using Klinika.Model;
using Klinika.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Controller
{
    public class MedicineController
    {

        private readonly MedicineService _MedicineService;
        
        public MedicineController (MedicineService medicineService)
        {
            _MedicineService = medicineService;
        }

        public List<Medicine> GetAllMedicines() => _MedicineService.GetAllMedication();

        public ObservableCollection<Medicine> PutListInObservableCollection(List<Medicine> medicines) => _MedicineService.PutListInObservableCollection(medicines);

        public Medicine GetMedicineById(string id) => _MedicineService.GetMedicineById(id);

        public void SaveMedicines(List<Medicine> partialMedicalList) => _MedicineService.SaveMedicines(partialMedicalList);

        public void SaveChangedMedicine(Medicine changedMedicine) => _MedicineService.SaveChangedMedicine(changedMedicine);

        public void SaveNewMedicine(Medicine medicine) => _MedicineService.SaveNewMedicine(medicine);

       
        public List<Medicine> MedicineListSorter(int sortChoise, List<Medicine> medicineList) => _MedicineService.MedicineListSorter(sortChoise, medicineList);

        public ObservableCollection<Medicine> SearchBy(int searchableitem, List<Medicine> medicineList, string searchBoxText) => _MedicineService.SearchBy(searchableitem, medicineList, searchBoxText);

        public ObservableCollection<Medicine> SearchByPrice(List<Medicine> medicineList, string minPrice, string maxPrice) => _MedicineService.SearchByPrice( medicineList, minPrice, maxPrice);

        

        public List<Medicine> GetAllMedicationWaitingForApproval() => _MedicineService.GetAllMedicationWaitingForApproval();


        public   ObservableCollection<Medicine> GetObservableListApprovalPending(ObservableCollection<Medicine> medicines) => _MedicineService.GetObservableListApprovalPending(medicines);

        public void MedicineApproval(Medicine medicineForApproval, User user) => _MedicineService.MedicineApproval(medicineForApproval, user);

        public void MedicineDecline(Medicine medicineForDecline, User activeUser, string description) =>  _MedicineService.MedicineDecline( medicineForDecline,  activeUser, description);


        public ObservableCollection<Medicine> GetAllApprovedAndDeclinedMedicines() => _MedicineService.GetAllApprovedAndDeclinedMedicines();

        public ObservableCollection<Medicine> GetAllApprovedMedicines() => _MedicineService.GetAllApprovedMedicines();

        public ObservableCollection<Medicine> GetAllADeclinedMedicines() => _MedicineService.GetAllADeclinedMedicines();

        public void AddQuantity(Medicine selectedMedicine, int quantity) => _MedicineService.AddQuantity(selectedMedicine, quantity);
    }


}

