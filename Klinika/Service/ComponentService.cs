using klinika.Model;
using Klinika.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Service
{
    public class ComponentService
    {


        private readonly ComponentRepository _ComponentRepo;


        public ComponentService(ComponentRepository componentRepository)
        {
            _ComponentRepo = componentRepository;
            

        }

        public List<Component> GetAllComponents() => _ComponentRepo.GetAll();

        public Component GetComponentByName(string name) => _ComponentRepo.GetByName(name);


        public void SaveNewMedicine(Component component) => _ComponentRepo.SaveNewItem(component);

        public void DeleteMedicin(Component component) => _ComponentRepo.Delete(component);
    }
}
