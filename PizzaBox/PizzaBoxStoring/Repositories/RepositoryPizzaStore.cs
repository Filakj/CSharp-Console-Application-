using System;
using System.Collections.Generic;
using PizzaBoxDomain.Abstracts;
using PizzaBoxDomain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;


namespace PizzaBoxStoring.Repositories
{
    public class RepositoryPizzaStore : IRepositoryPizzaStore<PizzaBoxDomain.Models.PizzaStore>
    {
        PizzaBoxDbContext db;

        public RepositoryPizzaStore()
        {
            db = new PizzaBoxDbContext();
        }

        public RepositoryPizzaStore(PizzaBoxDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }


        public void AddPizzaStore(PizzaStore pizzastore)
        {
            if (db.PizzaStore.Any(e => e.Storename == pizzastore.Storename) || pizzastore.Storename == null)
            {
                Console.WriteLine($"This Storename : {pizzastore.Storename} already exists. Please choose another Storename or Sign Up");
                return;
            }


            db.PizzaStore.Add(Mapper.Map(pizzastore));
            db.SaveChanges();
        }


        public IEnumerable<PizzaStore> getSpecial(string storename)
        {
            var query = from e in db.PizzaStore
                        where e.Storename.Equals(storename)
                        select e.PresetPizza;
            return (System.Collections.Generic.IEnumerable<PizzaBoxDomain.Models.PizzaStore>)query; 
        }


        public IEnumerable<PizzaStore> GetPizzaStore()
        {
            var query = from e in db.PizzaStore
                        select Mapper.Map(e);

            return query;
        }

        public void ModifyPizzaUser(PizzaStore pizzastore)
        {
            throw new NotImplementedException();
        }

        public void RemovePizzaUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
