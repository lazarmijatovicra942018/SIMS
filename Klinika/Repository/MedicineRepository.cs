using klinika.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Klinika.Repository
{
    public class MedicineRepository : GenericRepository<Medicine>
    {

        public Medicine GetById(string id)
        {
            List<Medicine> medicines = GetAll();
            foreach (Medicine medicine in medicines)
            {

                if (medicine.id.Equals(id)) { return medicine; }
            }
            return null;



        }

        public Medicine FindMedicineInCollectionById(string medicineId, ObservableCollection<Medicine> medicines)
        {
            Medicine medicineWithId = new Medicine();
            foreach (Medicine medicine in medicines)
            {
                if (medicine.id.Equals(medicineId))
                {
                    medicineWithId = medicine;
                    break;
                }
            }
            return medicineWithId;
        }


        public MedicineRepository()
        {
            filePath = "medicine.json";
        }

        internal ObservableCollection<Medicine> PutListInObservableCollection(bool v)
        {
            throw new NotImplementedException();
        }



    }
}
