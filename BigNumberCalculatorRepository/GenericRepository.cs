using System.Collections.Generic;
using System.Linq;

namespace BigNumberCalculator.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BigDataContext _context;
        public GenericRepository(BigDataContext context)
        {
            _context = context;
        }

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
