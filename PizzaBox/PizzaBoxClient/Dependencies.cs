using System;
using PizzaBoxDomain.Abstracts;
using PizzaBoxDomain.Models;
using PizzaBoxStoring.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;


namespace PizzaBoxClient
{
    public static class Dependencies
    {

        public static IRepositoryPizzaUser<PizzaBoxDomain.Models.PizzaUser> CreatePizzaUserRepository()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = configBuilder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBoxDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            var options = optionsBuilder.Options;

            PizzaBoxDbContext db = new PizzaBoxDbContext(options);
            return new PizzaBoxStoring.Repositories.RepositoryPizzaUser(db);
        }

        public static IRepositoryPizzaStore<PizzaBoxDomain.Models.PizzaStore> CreatePizzaStoreRepository()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = configBuilder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBoxDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            var options = optionsBuilder.Options;

            PizzaBoxDbContext db = new PizzaBoxDbContext(options);
            return new PizzaBoxStoring.Repositories.RepositoryPizzaStore(db);
        }

        public static IRepositoryPizzaOrder<PizzaBoxDomain.Models.PizzaOrder> CreatePizzaOrderRepository()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = configBuilder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBoxDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            var options = optionsBuilder.Options;

            PizzaBoxDbContext db = new PizzaBoxDbContext(options);
            return new PizzaBoxStoring.Repositories.RepositoryPizzaOrder(db);
        }

        public static IRepositoryPizza<PizzaBoxDomain.Models.Pizza> CreatePizzaPizza()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = configBuilder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBoxDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            var options = optionsBuilder.Options;

            PizzaBoxDbContext db = new PizzaBoxDbContext(options);
            return new PizzaBoxStoring.Repositories.RepositoryPizza(db);
        }



    }
}

