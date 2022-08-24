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
    }


}

