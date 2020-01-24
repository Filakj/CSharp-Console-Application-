using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxDomain.Abstracts
{
    public interface IRepositoryPizzaUser<T>
    {
        IEnumerable<T> GetPizzaUser();
        void AddPizzaUser(T pizzauser);

    }
}
