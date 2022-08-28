using Klinika.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika.Model
{
    public class Medicine
    {
        public string id { get; set; }

        public string name { get; set; }

        public string manufactur { get; set; }

        public IDictionary<string, Component> components { get; set; }

        public int quantity { get; set; }

        public double price { get; set; }



     
        public bool isDeclined {get; set;}

        public bool isApproved { get; set; }


        public List<User> ApprovedByUsers { get; set; } 

        public User DeclinedByUsers { get; set; }
        
        public string DeclineDescription { get; set; }

        public Medicine(string id, string name, string manufactur, IDictionary<string, Component> components, int quantity, double price )
        {
            this.id = id;
            this.name = name;
            this.manufactur = manufactur;
            this.components = components;
            this.quantity = quantity;
            this.price = price;
            this.isDeclined = false;
            this.isApproved = false;
            ApprovedByUsers = new List<User>();
            DeclinedByUsers = null;
            DeclineDescription = null;
        }

        public Medicine()
        {
        }
    }
}
