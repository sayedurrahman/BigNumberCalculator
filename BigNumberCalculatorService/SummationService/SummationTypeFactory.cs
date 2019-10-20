using BigNumberCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculator.Core.SummationService
{
    public class SummationFactory
    {
        /*
         * This class decides which type of summation to perform
         * Sum of two positive, sum of two negative or sum of one positive and one negative
         * */

        private readonly ITwoNumberSummation Instance;
        private readonly BigNumberString firstBigNumberString;
        private readonly BigNumberString secondBigNumberString;

        public SummationFactory(string firstNumber, string secondNumber)
        {
            firstBigNumberString = new BigNumberString(firstNumber);
            secondBigNumberString = new BigNumberString(secondNumber);
            Instance= GetSummationType(firstBigNumberString, secondBigNumberString);
        }

        public string DoTheSum()
        {
            return Instance.DoTheSum(firstBigNumberString, secondBigNumberString);
        }

        private ITwoNumberSummation GetSummationType(BigNumberString firstBigNumberString, BigNumberString secondBigNumberString)
        {
            if (firstBigNumberString.IsNegative && secondBigNumberString.IsNegative)
            {
                // means both are negative
                return new TwoNegativeNumberService();
            }
            else if (!firstBigNumberString.IsNegative && !secondBigNumberString.IsNegative)
            {
                // means both are positive
                return new TwoPositiveNumberService();
            }
            else
                return new OnePositiveOneNegativeNumberService();

        }
    }
}
