using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using BigNumberCalculator.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace BigNumberCalculator.Repository
{
    public class UserCalculatorRepository : GenericRepository<Calculation>
    {
        private readonly BigDataContext _context;
        public UserCalculatorRepository(BigDataContext context):base(context)
        {
            _context = context;
        }

        public List<Calculation> GetAllCalculation()
        {
            return _context.Set<Calculation>().Include(x => x.User).ToList();
        }

    }
}
