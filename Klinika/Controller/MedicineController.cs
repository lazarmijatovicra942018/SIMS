using klinika.Model;
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

        public   List<Medicine> MedicineListSorter(int sortChoise, List<Medicine> medicineList) => _MedicineService.MedicineListSorter(sortChoise, medicineList);

        public IEnumerable<Medicine> SearchBy(int searchableitem, List<Medicine> medicineList, string searchBoxText) => _MedicineService.SearchBy(searchableitem, medicineList, searchBoxText);

        public IEnumerable<Medicine> SearchByPrice(List<Medicine> medicineList, string minPrice, string maxPrice) => _MedicineService.SearchByPrice( medicineList, minPrice, maxPrice);

       
    }


}

