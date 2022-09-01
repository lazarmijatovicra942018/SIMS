using klinika.Enum;
using Klinika.Model;
using Klinika.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Klinika.Controller
{
    public class UserController
    {
        private readonly UserService _UserService;

        public UserController(UserService userService)
        {
            _UserService = userService;


        }




        public User GetActiveUser => _UserService.ActiveUser;

        public int GetShutDownCounter => _UserService.ShutDownCounter;

        public User GetUserByJmbg(string jmbg) => _UserService.GetUserByJmbg(jmbg);

        public User GetUserByEmail(string email) => _UserService.GetUserByEmail(email);

        public bool LoginValidationByEmailAndPassword(string email, string password) => _UserService.LoginValidation(email, password);

        public void SaveNewUser(string name , string lastName, string  password,string jmbg,string email, string phoneNumber, UserType userType) => _UserService.SaveNewUser(name,lastName,password,jmbg,email,phoneNumber,userType);

        public ObservableCollection<User> GetAllUsers() => _UserService.GetAllUsers();
        public void LogOut() => _UserService.LogOut();

        public ObservableCollection<User> FilteringUsers(int userTypeIndex) => _UserService.FilteringUsers(userTypeIndex);
        public List<User> UserSorting(int sortChoise, List<User> users) => _UserService.UserSorting(sortChoise, users);

        public void BlockUser(User selectedUser) => _UserService.BlockUser(selectedUser);

        public void UnBlockUser(User selectedUser) => _UserService.UnBlockUser(selectedUser);

    }
}
