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

        public List<Component> GetAllComponents() => _ComponentRepo.GetAll();

        public Component GetComponentByName(string name) => _ComponentRepo.GetByName(name);


        public void SaveNewMedicine(Component component) => _ComponentRepo.SaveNewItem(component);

        public void DeleteMedicin(Component component, System.Collections.ObjectModel.ObservableCollection<Component> components) => _ComponentRepo.Delete(component);
        
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

        public void Message()
        {
            MessageBox.Show("BozicJeBozicJe");
        }

    }
}
