using Klinika.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Controller
{
    public class ComponentController
    {
        private readonly ComponentService _ComponentService;

        public ComponentController(ComponentService componentService)
        {
            _ComponentService = componentService;
        }


    }
}
