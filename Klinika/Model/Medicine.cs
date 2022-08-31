using Klinika.Model;
using System;
using System.Collections.Generic;

namespace klinika.Model
{
    public class Medicine
    {
        private string Id;

        private string Name;

        private string Manufactur;

        private IDictionary<string, Component> Components;

        private int Quantity;

        private double Price;

        private bool IsDeclined;

        private bool IsApproved;


        private List<User> approvedByUsers;

        private User declinedByUsers;

        private string declineDescription;

        private DateTime DateForAddingQuantities;

        private int QuantityForAdding;


   
        public User DeclinedByUsers
        {
            get { return declinedByUsers; }
            set { declinedByUsers = value; }
        }

        public string id { 
            get { return Id; } 
            set { Id = value; } 
        }

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        public string manufactur
        {
            get { return Manufactur; }
            set { Manufactur = value; }
        }

        public IDictionary<string, Component> components
        {
            get { return Components; }
            set { Components = value; }
        }

        public int quantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }

        public double price
        {
            get { return Price; }
            set { Price = value; }
        }

        public bool isDeclined
        {
            get { return IsDeclined; }
            set { IsDeclined = value; }
        }

        public bool isApproved
        {
            get { return IsApproved; }
            set { IsApproved = value; }
        }

        public List<User> ApprovedByUsers
        {
            get { return approvedByUsers;  }
            set { approvedByUsers = value; }
        }

        public string DeclineDescription
        {
            get { return declineDescription; }
            set { declineDescription = value; }
        }

        public DateTime dateForAddingQuantities
        {
            get { return DateForAddingQuantities; }
            set { DateForAddingQuantities = value; }
        }

        public int quantityForAdding
        {
            get { return QuantityForAdding; }
            set { QuantityForAdding = value; }
        }


        public Medicine(string id, string name, string manufactur, IDictionary<string, Component> components, int quantity, double price)
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
            dateForAddingQuantities = new DateTime();
            quantityForAdding = 0;
        }

        public Medicine()
        {
        }
    }
}
