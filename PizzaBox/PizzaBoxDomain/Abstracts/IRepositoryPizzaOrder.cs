using System;
using System.Collections.Generic;
using System.Text;


namespace PizzaBoxDomain.Abstracts
{
    public interface IRepositoryPizzaOrder<T>
    {

            IEnumerable<T> GetPizzaOrder();
            void AddPizzaOrder(T pizzaorder);
            void ModifyPizzaOrder(T pizzaorder);
            void RemovePizzaOrder(int orderID);
        IEnumerable<T> GetPizzaOrderHistoryUser(string username);
    }
}
