using Klinika.Service;
using System;
using System.Collections.Generic;
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
    }
}
