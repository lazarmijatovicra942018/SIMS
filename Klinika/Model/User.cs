using klinika.Enum;

namespace Klinika.Model
{
    public class User
    {


        public string Name; 

        private string LastName;

        private string Password;

        private string Jmbg;

        private string Email;

        private string PhoneNumber;

        private UserType userTypE;

        private bool IsBaned;



        public string name { 
            get { return Name; } 
            set { Name = value; } 
        }
        public string lastName
        {
            get { return LastName; }
            set { LastName = value; }
        }

        public string password
        {
            get { return Password; }
            set { Password = value; }
        }

        public string jmbg
        {
            get { return Jmbg; }
            set { Jmbg = value; }
        }

        public string email
        {
            get { return Email; }
            set { Email = value; }
        }

        public string phoneNumber
        {
            get { return PhoneNumber; }
            set { PhoneNumber = value; }
        }

        public UserType userType { 
            get { return userTypE; } 
            set { userTypE = value; } 
        }

        public bool isBaned
        {
            get { return IsBaned; }
            set { IsBaned = value; }

        }

        public User(string name, string lastName, string password, string jmbg, string email, string phoneNumber, UserType userType)
        {
            this.name = name;
            this.lastName = lastName;
            this.password = password;
            this.jmbg = jmbg;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.userType = userType;
            this.isBaned = false;

        }

        override
        public string ToString()
        {
            if (userType == UserType.Pharmacist) { return "Farmaceut  " + name + " " + lastName; ; };
            if (userType == UserType.Doctor) { return "Doktor  " + name + " " + lastName; };
            if (userType == UserType.Manager) { return "Upravnik  " + name + " " + lastName; };
            return "";


        }

    }
}
