using System;
using System.Collections.Generic;
using System.Text;
using BigNumberCalculator.Core.Models;

namespace BigNumberCalculator.Core.SummationService
{
    public class TwoNegativeNumberService : ITwoNumberSummation
    {
        public string DoTheSum(BigNumberString firstNumberString, BigNumberString secondNumberString)
        {
            /*
             * Sum of two negative number means sum of those number and minus sign in the beginning
             * */
            return "-" + new TwoPositiveNumberService().DoTheSum(firstNumberString, secondNumberString);
        }
    }
}
