using klinika.Model;
using Klinika.Repository;
using System;
using System.Collections.Generic;
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
    }
}
