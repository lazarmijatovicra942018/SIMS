using klinika.Model;
using Klinika.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Klinika.Service
{
    public class ComponentService
    {


        private readonly ComponentRepository _ComponentRepo;


        public ComponentService(ComponentRepository componentRepository)
        {
            _ComponentRepo = componentRepository;


        }

        
        public IDictionary<string, Component> ConvertObservableCollectionToIDictionary(System.Collections.ObjectModel.ObservableCollection<Component> components)
        {
            IDictionary<string, Component> componentsIDictionary = new Dictionary<string, Component>();

            foreach (Component component in components)
            {
                componentsIDictionary.Add(component.componentName, component);
            }

            return componentsIDictionary;

        }


         public System.Collections.ObjectModel.ObservableCollection<Component> AddComponent(string componentName , string componentDescription, ObservableCollection<Component> components)
        {

            Component component = new Component(componentName, componentDescription);
            components.Add(component);

            return components;
        }


        public System.Collections.ObjectModel.ObservableCollection<Component> DeleteComponent(Component component , ObservableCollection<Component> components)
        {
            components.Remove(component);
            return components;
        }

       

    }
}
