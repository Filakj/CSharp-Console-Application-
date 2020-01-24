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
                Email = pizzauser.Email,
                UserJoinDate = pizzauser.UserJoinDate,
                LastOrderTime = pizzauser.LastOrderTime,
                LastOrderStore = pizzauser.LastOrderStore
                
               

            };
            }

        public static PizzaBoxDomain.Models.PizzaStore Map(PizzaBoxDomain.Models.PizzaStore pizzastore)
        {
            return new PizzaBoxDomain.Models.PizzaStore()
            {
                Storename = pizzastore.Storename,
                StorePassword = pizzastore.StorePassword,
                Cell = pizzastore.Cell,
                StoreAddress = pizzastore.StoreAddress,
                PresetSpecial = pizzastore.PresetSpecial,
                PresetPizzaId = pizzastore.PresetPizzaId,
                StoreJoinDate = pizzastore.StoreJoinDate
                

                
            };
        }

        public static PizzaBoxDomain.Models.PizzaOrder Map (PizzaBoxDomain.Models.PizzaOrder pizzaorder) //Map(string username, string storename, float cost, int pid)
        {
            return new PizzaBoxDomain.Models.PizzaOrder()
            {
                Orderid = pizzaorder.Orderid,
                Username = pizzaorder.Username,
                Storename = pizzaorder.Storename,
                Cost = pizzaorder.Cost,
                PizzaOne = pizzaorder.PizzaOne,
                PizzaTwo = pizzaorder.PizzaTwo, 

                OrderDate = pizzaorder.OrderDate

            };
        }

        public static PizzaBoxDomain.Models.Pizza Map(PizzaBoxDomain.Models.Pizza pizza)
        {
            return new PizzaBoxDomain.Models.Pizza()
            {
                Cost = pizza.Cost,
                Crust = pizza.Crust,
                Size = pizza.Size,
                ExtraCheese = pizza.ExtraCheese,
                Bacon = pizza.Bacon,
                Pepperoni = pizza.Pepperoni,
                Mozzerella = pizza.Mozzerella,
                Sausage = pizza.Sausage,
                Pineapple = pizza.Pineapple,
                Onion = pizza.Onion,
                Chicken = pizza.Chicken,
                Pepper = pizza.Pepper
            };
        }



    }//class
}
