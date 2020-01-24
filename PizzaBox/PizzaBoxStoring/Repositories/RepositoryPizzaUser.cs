using System;
using System.Collections.Generic;
using PizzaBoxDomain.Abstracts;
using PizzaBoxDomain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace PizzaBoxStoring.Repositories
{
    public class RepositoryPizzaUser : IRepositoryPizzaUser<PizzaBoxDomain.Models.PizzaUser>
    {

        PizzaBoxDbContext db;

        public RepositoryPizzaUser()
        {
            db = new PizzaBoxDbContext();
        }

        public RepositoryPizzaUser(PizzaBoxDbContext db)
        {
            this.db = db?? throw new ArgumentNullException(nameof(db));
        }



        //CREATE 

        public void AddPizzaUser(PizzaUser pizzauser)
        {
            if (db.PizzaUser.Any(e => e.Username == pizzauser.Username) || pizzauser.Username == null)
            {
                Console.WriteLine($"This username : {pizzauser.Username} already exists. Please choose another");
                return;
            }
            
         
            db.PizzaUser.Add(Mapper.Map(pizzauser));
            db.SaveChanges();

        }



        public IEnumerable<PizzaUser> GetPizzaUser()
        {
            var query = from e in db.PizzaUser
                        select Mapper.Map(e);

            return query;
        }


    }
}
