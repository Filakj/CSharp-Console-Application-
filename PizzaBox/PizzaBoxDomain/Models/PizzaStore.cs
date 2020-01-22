using System;
using System.Collections.Generic;

namespace PizzaBoxDomain.Models
{
    public partial class PizzaStore
    {

        public PizzaStore(string a, string b, string c, string d)
        {
            Storename = a;
            StorePassword = b;
            Cell = c;
            StoreAddress = d;
        }

        public PizzaStore()
        {
            PizzaOrder = new HashSet<PizzaOrder>();
            PizzaUser = new HashSet<PizzaUser>();
        }

        public string Storename { get; set; }
        public string StorePassword { get; set; }
        public string Cell { get; set; }
        public string StoreAddress { get; set; }
        public string? PresetSpecial { get; set; }
        public int? PresetPizzaId { get; set; }
        public DateTime? StoreJoinDate { get; set; }

        public virtual Pizza PresetPizza { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrder { get; set; }
        public virtual ICollection<PizzaUser> PizzaUser { get; set; }
    }
}
