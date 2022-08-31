using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika.Model
{
    public class Component 
    {
        public string componentName { get; set; }

        public string componentDescription { get; set; }

        public Component(string componentName, string componentDescription)
        {
            this.componentName = componentName;
            this.componentDescription = componentDescription;
        }
    }
}
