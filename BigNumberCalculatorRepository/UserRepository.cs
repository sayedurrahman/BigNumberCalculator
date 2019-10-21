using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using BigNumberCalculator.Repository.Models;

namespace BigNumberCalculator.Repository
{
    public class UserRepository : GenericRepository<User>
    {
        private readonly BigDataContext _context;
        public UserRepository(BigDataContext context):base(context)
        {
            _context = context;
        }

        public User GetUserByName(string userName)
        {
            return _context.Set<User>().Where(x => x.UserName == userName).SingleOrDefault();
        }

    }
}
