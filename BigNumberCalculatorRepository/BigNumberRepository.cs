using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculatorRepository
{
    public class BigNumberRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BigDataContext _context;
        public BigNumberRepository(BigDataContext context)
        {
            _context = context;
        }
        //private readonly CHSRContext _context;

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool IsExists(int id)
        {
            T obj = _context.Set<T>().Find(id);
            return obj != null;
        }
    }
}
