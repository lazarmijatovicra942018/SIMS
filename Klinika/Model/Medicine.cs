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

        public string passwor { get; set; }

        public string manufacture { get; set; }

        public IDictionary<string, Component> components { get; set; }

        public int count { get; set; }

        public bool verification { get; set; }

        public string isDeleted { get; set; }




    }
}
