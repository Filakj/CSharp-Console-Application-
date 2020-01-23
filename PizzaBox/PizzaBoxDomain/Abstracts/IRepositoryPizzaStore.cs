using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxDomain.Abstracts
{
    public interface IRepositoryPizzaStore<T>
    {
        IEnumerable<T> GetPizzaStore();
        void AddPizzaStore(T pizzastore);
        IEnumerable<T> GetOrders(string s);


    }
}
