using Klinika.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Klinika.Repository
{
    public class UserRepository : GenericRepository<User>
    {
        


        public User GetByEmail(string email)
        {
            List<User> users = GetAll();
            foreach(User user in users)
            {

                if(user.email.Equals(email)) { return user; }



            }
            return null;

        }

        public User GetByJmbg(string jmbg)
        {
            List<User> users = GetAll();
            foreach (User user in users)
            {

                if (user.jmbg.Equals(jmbg)) { return user; }



            }
            return null;
        }


        public UserRepository()
        {
            filePath = "user.json";
        }


    }
}
