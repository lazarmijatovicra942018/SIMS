using klinika.Enum;
using Klinika.Model;
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
            User user = _UserService.activeUser;


        }

        public User GetActiveUser => _UserService.activeUser;
        public int GetShutDownCounter => _UserService.shutDownCounter;



        public bool LoginValidationByEmailAndPassword(string email, string password) => _UserService.LoginValidation(email, password);



    }
}
