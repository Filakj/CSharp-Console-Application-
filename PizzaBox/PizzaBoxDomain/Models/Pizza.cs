using System;
using System.Collections.Generic;
using System.Numerics;

namespace PizzaBoxDomain.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaOrderPizzaEightNavigation = new HashSet<PizzaOrder>();
            PizzaOrderPizzaFiveNavigation = new HashSet<PizzaOrder>();
            PizzaOrderPizzaFourNavigation = new HashSet<PizzaOrder>();
            PizzaOrderPizzaNineNavigation = new HashSet<PizzaOrder>();
            PizzaOrderPizzaOneNavigation = new HashSet<PizzaOrder>();
            PizzaOrderPizzaSevenNavigation = new HashSet<PizzaOrder>();
            PizzaOrderPizzaSixNavigation = new HashSet<PizzaOrder>();
            PizzaOrderPizzaTenNavigation = new HashSet<PizzaOrder>();
            PizzaOrderPizzaThreeNavigation = new HashSet<PizzaOrder>();
            PizzaOrderPizzaTwoNavigation = new HashSet<PizzaOrder>();
            PizzaStore = new HashSet<PizzaStore>();
        }

        public int Pid { get; set; }
        public decimal Cost { get; set; }
        public string Crust { get; set; }
        public string Size { get; set; }
        public int? Cheese { get; set; }
        public int? Sauce { get; set; }
        public int ExtraCheese { get; set; }
        public int Bacon { get; set; }
        public int Pepperoni { get; set; }
        public int Mozzerella { get; set; }
        public int Sausage { get; set; }
        public int Pineapple { get; set; }
        public int Onion { get; set; }
        public int Chicken { get; set; }
        public int Pepper { get; set; }

        public virtual ICollection<PizzaOrder> PizzaOrderPizzaEightNavigation { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrderPizzaFiveNavigation { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrderPizzaFourNavigation { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrderPizzaNineNavigation { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrderPizzaOneNavigation { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrderPizzaSevenNavigation { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrderPizzaSixNavigation { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrderPizzaTenNavigation { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrderPizzaThreeNavigation { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrderPizzaTwoNavigation { get; set; }
        public virtual ICollection<PizzaStore> PizzaStore { get; set; }
    }
}




#region old
/*
namespace PizzaBoxDomain
{
    

    public class Pizza
    {
        public Pizza()
        {
            Store = new HashSet<Store>();
            Order = new HashSet<Order>(); 
        }

        public int pid { get; set; }
        public float? cost { get; set; }

        public string crust { get; set; }
        public string size { get; set; }

        public int cheese { get; set; }
        public int sauce { get; set; }

        public int extra_cheese { get; set; }
        public int bacon { get; set; }
        public int pepperoni { get; set; }
        public int mozzerella { get; set; }
        public int sausage { get; set; }
        public int pineapple { get; set; }
        public int onion { get; set; }
        public int chicken { get; set; }
        public int pepper { get; set; }

        public virtual ICollection<Store> Store { get; set;  }
        //public virtual Order order { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        /*
        //cost 
        private float price;
        private float baseCost = 10.00f;

        //default toppings
        private int cheese = 1;
        private int sauce = 1;

        
        private string crust;
        private string size;

        
        

        private static string[] crusts = { "Regular", "Thin", "Deep Dish", "Stuffed" };
        static string[] sizes = { "Small", "Medium", "Large", "X-Large" };

        private int numToppings; // 5 topings total , including cheese and sauce  

        //optional toppings
        
        private int extraCheese;
        private int bacon;
        private int pepperoni;
        private int mozzerella;
        private int mushroom;
        private int sausage;
        private int pineapple;
        private int onion;
        private int chicken;
        private int pepper;


        public Pizza()
        {   
        }

        // Compute Price
        public float ComputePrice() {

            float costMultiplier = 1.0f;

            switch (this.crust)
            {
                case "Deep Dish":
                    costMultiplier += 0.2f; 
                    break;
                case "Thin":
                    costMultiplier += 0.1f;
                    break;
                case "Stuffed":
                    costMultiplier += 0.3f;
                    break;
               
            }// crust


            switch (this.size)
            {
                case "Medium":
                    costMultiplier += 0.1f;
                    break;
                case "Large":
                    costMultiplier += 0.2f;
                    break;
                case "X-Large":
                    costMultiplier += 0.3f;
                    break;
            }//size

            //each topic is one dollar
            this.baseCost += (float)this.numToppings; 
            

            this.price = costMultiplier * this.baseCost;
            return this.price; 

        }//compute price 





        public Pizza customPizza(){
            Console.WriteLine("Ok Lets Customize This Pizza");
            Console.WriteLine("Default topics are Cheese and Sauce");
            Console.WriteLine("Choose up to three remaining topings");

            //TODO make custom pizza 

            Pizza customP = new Pizza();
            return customP;
        }


       
  


    }
}
*/
#endregion