using System;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculator.Core.Models
{
    public class UserCalculation
    {
        public DateTime CalculationDate { get; set; }
        public string UserName { get; set; }
        public string BigNumber1 { get; set; }
        public string BigNumber2 { get; set; }
        public string Sum { get; set; }
    }
}
