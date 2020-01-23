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

            db.Pizza.Add(Mapper.Map(pizza));
            db.SaveChanges();
        }

        public IEnumerable<Pizza> GetPizza()
        {
            var query = from e in db.Pizza
                        select Mapper.Map(e);

            return query;
        }



        public int GetLastPizza()
        {
            var query = (from p in db.Pizza
                       orderby p.Pid descending
          
                       select p.Pid).Take(1);

            int result = query.FirstOrDefault();

            return result;
        }



       
    }
}
