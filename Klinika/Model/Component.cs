namespace klinika.Model
{
    public class Component
    {
        private string ComponentName;

        private string ComponentDescription;

        public string componentDescription { 
            get { return ComponentDescription; } 
            set { ComponentDescription = value; }
        }

        public string componentName { 
            get { return ComponentName; }
            set { ComponentName = value; }
        }


        public Component(string componentName, string componentDescription)
        {
            this.componentName = componentName;
            this.componentDescription = componentDescription;
        }
    }
}
