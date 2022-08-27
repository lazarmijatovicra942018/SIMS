using klinika.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Model
{
    public class User 
    {


        public string name { get; set; }

        public string lastName { get; set; }


        public string password { get; set; }


        public string jmbg { get; set; }

        public string email { get; set; }

      
      

        public string phoneNumber { get; set; }

        public UserType userType { get; set; }

        public bool isBaned { get; set; }

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
