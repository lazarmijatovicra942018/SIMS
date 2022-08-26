using Klinika.Model;
using Klinika.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Service
{
    public class UserService
    {
        private readonly UserRepository _UserRepo;
        public   User activeUser { 
            get ; 
            set; }

        public int shutDownCounter { get; set; }

        public UserService(UserRepository userRepository)
        {
            _UserRepo = userRepository;

        }

        public List<User> GetAllUsers() => _UserRepo.GetAll();

        public User GetUserByJmbg(string jmbg) => _UserRepo.GetByJmbg(jmbg);

        public User GetUserByEmail(string email) => _UserRepo.GetByEmail(email);

        public void SaveNewUser(User user) => _UserRepo.SaveNewItem(user);

        public void LogOut()
        {
            activeUser = null;
            shutDownCounter = 0;

        }

        public void DeleteUser(User user) => _UserRepo.Delete(user);



        public bool LoginValidation(string email , string password)
        {
            User user = GetUserByEmail(email);
            if (user == null)
            {
                shutDownCounter++;
                return false;
            }
            
            if (user.password.Equals(password) && user!=null)
              {
                    
                    activeUser = user;
                    shutDownCounter = 0;
                    return true;              
              }

            shutDownCounter++;

            return false;
        }


    }
}
