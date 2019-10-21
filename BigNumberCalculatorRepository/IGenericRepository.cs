using System;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculator.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Save();
        bool IsExists(int id);
    }
}
