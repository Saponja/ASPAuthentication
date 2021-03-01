using System;
using System.Collections.Generic;

namespace Airport.Data
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Add(T item);
        void Remove(T item);
        T FindById(int id);
    }
}
