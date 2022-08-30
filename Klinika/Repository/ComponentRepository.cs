using klinika.Model;
using System.Collections.Generic;

namespace Klinika.Repository
{
    public class ComponentRepository : GenericRepository<Component>
    {
        public Component GetByName(string name)
        {
            List<Component> components = GetAll();
            foreach (Component component in components)
            {

                if (component.componentName.Equals(name)) { return component; }



            }
            return null;

        }


        public ComponentRepository()
        {
            filePath = "component.json";
        }
    }
}
