using System;
using System.Collections.Generic;
using System.Text;


namespace PizzaBoxDomain.Abstracts
{
    public interface IRepositoryPizzaOrder<T>
    {

        IEnumerable<T> GetPizzaOrder();
        void AddPizzaOrder(T pizzaorder);
        IEnumerable<T> GetPizzaOrderHistoryUser(string username);
        IEnumerable<T> GetOrders(string storename);
    }
}
