using System;
using System.Collections.Generic;
using PizzaBoxDomain.Abstracts;
using PizzaBoxDomain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace PizzaBoxStoring.Repositories
{
    public class RepositoryPizzaOrder : IRepositoryPizzaOrder<PizzaBoxDomain.Models.PizzaOrder>
    {
        PizzaBoxDbContext db;

        public RepositoryPizzaOrder()
        {
            db = new PizzaBoxDbContext();
        }

        public RepositoryPizzaOrder(PizzaBoxDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }


        // METHODS

        public void AddPizzaOrder(PizzaOrder pizzaorder){//(string username, string storename, float cost, int pid) { 
      
            /*
            if (db.PizzaOrder.Any(e => e.Orderid == pizzaorder.Orderid))  //|| Ordered.Username == null)
            {
                Console.WriteLine($"This order : {pizzaorder.Orderid} already exists. Please try again");
                return;
            }
            */

            db.PizzaOrder.Add(Mapper.Map(pizzaorder));
            db.SaveChanges();
        }

        public IEnumerable<PizzaOrder> GetPizzaOrder()
        {
            var query = from e in db.PizzaOrder
                        select Mapper.Map(e);

            return query;
        }

        public IEnumerable<PizzaOrder> GetPizzaOrderHistoryUser(string username)
        {
            var query = from e in db.PizzaOrder where (e.Username.Equals(username))
                        select Mapper.Map(e);
            return query; 
        }




        public void ModifyPizzaOrder(PizzaOrder pizzaorder)
        {
            throw new NotImplementedException();
        }

        public void RemovePizzaOrder(int orderID)
        {
            throw new NotImplementedException();
        }
    }
}
