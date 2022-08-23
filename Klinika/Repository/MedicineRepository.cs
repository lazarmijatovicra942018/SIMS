using klinika.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public MedicineRepository()
        {
            filePath = "medicine.json";
        }
    }
}
