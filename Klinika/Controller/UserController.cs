using Klinika.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Controller
{
    public class UserController
    {
        private readonly UserService _UserService;


        public UserController(UserService userService)
        {
            _UserService = userService; 


        }


    }
}
