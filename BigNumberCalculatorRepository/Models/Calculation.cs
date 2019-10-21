using System;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculator.Repository.Models
{
    public class Calculation
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string BigNumber1 { get; set; }
        public string BigNumber2 { get; set; }
        public string Sum { get; set; }
        public DateTime CalculationDate { get; set; }

        public User User { get; set; }
    }
}
