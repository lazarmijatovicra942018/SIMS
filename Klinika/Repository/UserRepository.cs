using Klinika.Model;
using System.Collections.Generic;
using System.Linq;

namespace Klinika.Repository
{
    public class UserRepository : GenericRepository<User>
    {



        public User GetByEmail(string email)
        {
            List<User> users = GetAll();
            foreach (User user in users)
            {

                if (user.email.Equals(email)) { return user; }



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


        public void SaveChangedUser(User changedUser)
        {

            List<User> userList = GetAll();
            foreach (User user in userList.ToList())
            {
                if (changedUser.jmbg == user.jmbg)
                {
                    userList.Remove(user);

                }
            }

            if (changedUser != null) { userList.Add(changedUser); }

            Serialize(userList);

        }

    }
}
