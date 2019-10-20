using System;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculatorRepository.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }

        public ICollection<Calculation> Calculations { get; set; }
    }
}
