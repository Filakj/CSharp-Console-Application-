using System;
using System.Collections.Generic;

namespace PizzaBoxDomain.Models
{
    public partial class PizzaUser
    {

        public PizzaUser(string a, string b, string c, string d, string e, string f, string g)
        {
            Username = a;
            UserPassword = b;
            FirstName = c;
            LastName = d;
            Cell = e;
            UserAddress = f;
            Email = g; 

        }

        public PizzaUser()
        {
            PizzaOrder = new HashSet<PizzaOrder>();
        }

        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cell { get; set; }
        public string UserAddress { get; set; }
        public string Email { get; set; }
        public DateTime? LastOrderTime { get; set; }
        public string LastOrderStore { get; set; }
        public DateTime? UserJoinDate { get; set; }

        public virtual PizzaStore LastOrderStoreNavigation { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrder { get; set; }
    }
}
