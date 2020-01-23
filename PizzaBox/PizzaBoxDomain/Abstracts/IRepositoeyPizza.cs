using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxDomain.Abstracts
{
    public interface IRepositoryPizza<T>
    {

        IEnumerable<T> GetPizza();
        void AddPizza(T pizza);
        int GetLastPizza();

    }
}
