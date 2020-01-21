using System;
using System.Collections.Generic;
using PizzaBoxDomain.Abstracts;
using PizzaBoxDomain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace PizzaBoxStoring.Repositories
{
    public class RepositoryPizza : IRepositoryPizza<PizzaBoxDomain.Models.Pizza>
    {
        PizzaBoxDbContext db;

        public RepositoryPizza()
        {
            db = new PizzaBoxDbContext();
        }

        public RepositoryPizza(PizzaBoxDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }



        // Methods

        public void AddPizza(Pizza pizza)
        {
            /*
            if (db.PizzaUser.Any(e => e.Username == pizzauser.Username) || pizzauser.Username == null)
            {
                Console.WriteLine($"This username : {pizzauser.Username} already exists. Please choose another");
                return;
            }
            */

            db.Pizza.Add(Mapper.Map(pizza));
            db.SaveChanges();
        }

        public IEnumerable<Pizza> GetPizza()
        {
            var query = from e in db.Pizza
                        select Mapper.Map(e);

            return query;
        }

        public void ModifyPizza(Pizza pizzastore)
        {
            throw new NotImplementedException();
        }

        public void RemovePizza(string username)
        {
            throw new NotImplementedException();
        }

        public void RemovePizza(int pid)
        {
            throw new NotImplementedException();
        }
    }
}
