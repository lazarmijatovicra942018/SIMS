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


        public UserService(UserRepository userRepository)
        {
            _UserRepo = userRepository;

        }

        public List<User> GetAllUsers() => _UserRepo.GetAll();

        public User GetUserByJmbg(string jmbg) => _UserRepo.GetByJmbg(jmbg);

        public User GetUserByEmail(string email) => _UserRepo.GetByEmail(email);

        public void SaveNewUser(User user) => _UserRepo.SaveNewItem(user);

        public void DeleteUser(User user) => _UserRepo.Delete(user);




    }
}
