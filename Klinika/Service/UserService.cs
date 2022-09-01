using klinika.Enum;
using Klinika.Model;
using Klinika.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Klinika.Service
{
    public class UserService
    {
        private readonly UserRepository _UserRepo;
        
        private User activeUser;
        
        public User ActiveUser
        {
            get { return activeUser; }
            set { activeUser = value; }
        }

        private int shutDownCounter;

        public int ShutDownCounter
        {
            get { return shutDownCounter; }
            set { shutDownCounter = value; }
        }

        public UserService(UserRepository userRepository)
        {
            _UserRepo = userRepository;

        }

        #region Get

        public User GetUserByJmbg(string jmbg) => _UserRepo.GetByJmbg(jmbg);


        public User GetUserByEmail(string email) => _UserRepo.GetByEmail(email);

        public ObservableCollection<User> GetAllUsers()
        {
            ObservableCollection<User> users = new ObservableCollection<User>(_UserRepo.GetAll());

            return users;
        }

        #endregion

        #region Save
        public void SaveNewUser(string name, string lastName, string password, string jmbg, string email, string phoneNumber, UserType userType)
        {   User user = new User(name, lastName, password, jmbg, email, phoneNumber, userType);
            _UserRepo.SaveNewItem(user);
        }

        #endregion

        #region Log
        public void LogOut()
        {
            activeUser = null;
            shutDownCounter = 0;

        }

     
      
        public bool LoginValidation(string email, string password)
        {
            User user = GetUserByEmail(email);


            if (user == null)
            {
                shutDownCounter++;
                MessagesNotLoggedInCorrectly("notExist");
            }
            else if (user.isBaned)
            {
                shutDownCounter++;
                MessagesNotLoggedInCorrectly("baned");
            }
            else if (user.password.Equals(password) && user != null)
            {

                activeUser = user;
                shutDownCounter = 0;
                return true;
            }
            else
            {

                shutDownCounter++;

                MessagesNotLoggedInCorrectly("wrongPassword");
            }

            return false;
        }


        private void MessagesNotLoggedInCorrectly(string returnMessage)
        {
            if (returnMessage == "notExist")
            {
                MessageBox.Show("Email  nije validan .");
            }
            else if (returnMessage == "wrongPassword")
            {
                MessageBox.Show("Sifra  nije pravilno napisana .");

            }
            else if (returnMessage == "baned")
            {
                MessageBox.Show("Korisnik je blokiran .");

            }
        }

        #endregion

        #region Filter

        public ObservableCollection<User> FilteringUsers(int userTypeIndex)
        {
            List<User> users = _UserRepo.GetAll();
            ObservableCollection<User> filteredUsers = new ObservableCollection<User>(users);

            if (userTypeIndex == 3) { return filteredUsers; }

            foreach (User user in users)
            {
                if ((int)user.userType != userTypeIndex)
                {
                    filteredUsers.Remove(user);
                }
            }

            return filteredUsers;
        }

        #endregion

        #region Sort

        public List<User> UserSorting(int sortChoise, List<User> users)
        {
            if (sortChoise == 0)
            {
                users.Sort((a, b) => a.Name.CompareTo(b.Name));
            }
            else if (sortChoise == 1)
            {
                users.Sort((a, b) => a.lastName.CompareTo(b.lastName));

            }

            return users;
        }

        #endregion

        #region BlockUnblock

        public void BlockUser(User selectedUser)
        {
            selectedUser.isBaned = true;
            _UserRepo.SaveChangedUser(selectedUser);

        }

        public void UnBlockUser(User selectedUser)
        {
            selectedUser.isBaned = false;
            _UserRepo.SaveChangedUser(selectedUser);

        }

        #endregion
    }
}
