using Klinika.Service;
using System.Collections.Generic;
using System.ComponentModel;
using klinika.Model;

namespace Klinika.Controller
{
    public class ComponentController
    {
        private readonly ComponentService _ComponentService;

        public ComponentController(ComponentService componentService)
        {
            _ComponentService = componentService;
        }

        public System.Collections.ObjectModel.ObservableCollection<klinika.Model.Component> AddComponent(string componentName, string componentDescription, System.Collections.ObjectModel.ObservableCollection<klinika.Model.Component> components) => _ComponentService.AddComponent(componentName, componentDescription, components);

        public System.Collections.ObjectModel.ObservableCollection<klinika.Model.Component> DeleteComponent(klinika.Model.Component component, System.Collections.ObjectModel.ObservableCollection<klinika.Model.Component> components) => _ComponentService.DeleteComponent(component, components);

    }
}
