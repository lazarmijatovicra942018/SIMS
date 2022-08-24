using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using klinika.Model;

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


        public ComponentRepository(){
            filePath = "component.json";
        }
    }
}
