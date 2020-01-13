using System;
using System.Collections.Generic;

namespace PizzaBoxDomain
{
    public class Store
    {
        //Data Members for a store 
        private string name;
        private string address;

        // Dynamic Structures to store other objects 
        private Dictionary<Pizza, int> sales;

        private List<User> users; //customers 
        //Dynamic Structures to store data types 
        private Dictionary<string, int> inventory;


        //----------------Properties-----------//


        /*
         *
         */
        public Store(string name, string address)
        {
            this.name = name;
            this.address = address;
            this.sales = new Dictionary<Pizza, int>();
            this.users = new List<User>();
            this.inventory = new Dictionary<string, int>(); 
        }


        public void setInventory()
        {
           
        }





    }
}
