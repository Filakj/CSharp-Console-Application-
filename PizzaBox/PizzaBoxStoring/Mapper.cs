using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBoxDomain;

namespace PizzaBoxStoring
{
    class Mapper
    {
            public static PizzaBoxDomain.Models.PizzaUser Map(PizzaBoxDomain.Models.PizzaUser pizzauser)
            {
            return new PizzaBoxDomain.Models.PizzaUser()
            {
                Username = pizzauser.Username,
                UserPassword = pizzauser.UserPassword,
                FirstName = pizzauser.FirstName,
                LastName = pizzauser.LastName,
                Cell = pizzauser.Cell,
                UserAddress = pizzauser.UserAddress,
                Email = pizzauser.Email

            };
            }

        public static PizzaBoxDomain.Models.PizzaStore Map(PizzaBoxDomain.Models.PizzaStore pizzastore)
        {
            return new PizzaBoxDomain.Models.PizzaStore()
            {
                Storename = pizzastore.Storename,
                StorePassword = pizzastore.StorePassword,
                Cell = pizzastore.Cell,
                StoreAddress = pizzastore.StoreAddress
                
            };
        }


    }//class
    }
