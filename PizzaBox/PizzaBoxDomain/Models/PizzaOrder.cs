using System;
using System.Collections.Generic;

namespace PizzaBoxDomain.Models
{
    public partial class PizzaOrder
    {
        public int Orderid { get; set; }
        public string Username { get; set; }
        public string Storename { get; set; }
        public decimal Cost { get; set; }
        public int PizzaOne { get; set; }
        public int? PizzaTwo { get; set; }
        public int? PizzaThree { get; set; }
        public int? PizzaFour { get; set; }
        public int? PizzaFive { get; set; }
        public int? PizzaSix { get; set; }
        public int? PizzaSeven { get; set; }
        public int? PizzaEight { get; set; }
        public int? PizzaNine { get; set; }
        public int? PizzaTen { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Pizza PizzaEightNavigation { get; set; }
        public virtual Pizza PizzaFiveNavigation { get; set; }
        public virtual Pizza PizzaFourNavigation { get; set; }
        public virtual Pizza PizzaNineNavigation { get; set; }
        public virtual Pizza PizzaOneNavigation { get; set; }
        public virtual Pizza PizzaSevenNavigation { get; set; }
        public virtual Pizza PizzaSixNavigation { get; set; }
        public virtual Pizza PizzaTenNavigation { get; set; }
        public virtual Pizza PizzaThreeNavigation { get; set; }
        public virtual Pizza PizzaTwoNavigation { get; set; }
        public virtual PizzaStore StorenameNavigation { get; set; }
        public virtual PizzaUser UsernameNavigation { get; set; }
    }
}
