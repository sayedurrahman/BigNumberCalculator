using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BigNumberCalculator.Core.ArithmeticOparationService;
using BigNumberCalculator.Core.Models;

namespace BigNumberCalculator.Core.SummationService
{
    public class OnePositiveOneNegativeNumberService : ITwoNumberSummation
    {
        private readonly IArithmeticService arithmeticService;
        public OnePositiveOneNegativeNumberService()
        {
            arithmeticService = SummationHelper.ArithmeticService;
        }
        public string DoTheSum(BigNumberString firstbigNumberString, BigNumberString secondBigNumberString)
        {
            /*
             * positive number + negative number
             * = positive number + 9's complement of negative number
             * if result has a carry, add the carry with the result, this is the final result and result is a positive number
             * if result do not has a carry, do the 9's complement on result, this is the final result and result is a Negative Number
             * https://www.geeksforgeeks.org/9s-complement-decimal-number/
             * */

            // Variables
            int carry = 0;
            string fractionString = string.Empty;
            BigNumberString negativeNumberString;
            BigNumberString positiveNumberString;

            if (firstbigNumberString.IsNegative)
            {
                negativeNumberString = firstbigNumberString;
                positiveNumberString = secondBigNumberString;
            }
            else
            {
                positiveNumberString = firstbigNumberString;
                negativeNumberString = secondBigNumberString;
            }
            
            // before we do 9's complement of negative number we must check if it has digit equals to or greater then positive counter part
            // else it end up wrong answer
            // if it is fractional add zero at end
            // if it is integral add zero at beginning
            if (positiveNumberString.FractionalPartDigitList.Count > negativeNumberString.FractionalPartDigitList.Count)
            {
                foreach (var i in Enumerable.Range(0, positiveNumberString.FractionalPartDigitList.Count - negativeNumberString.FractionalPartDigitList.Count))
                {
                    negativeNumberString.FractionalPartDigitList.Add(0);
                }
            }

            if (positiveNumberString.IntegralPartDigitList.Count > negativeNumberString.IntegralPartDigitList.Count)
            {
                foreach (var i in Enumerable.Range(0, positiveNumberString.IntegralPartDigitList.Count - negativeNumberString.IntegralPartDigitList.Count))
                {
                    negativeNumberString.IntegralPartDigitList.Insert(0, 0);
                }

            }

            // 9's complement
            var ncOfFraction = arithmeticService.DoNinesComplement(negativeNumberString.FractionalPartDigitList);
            var ncOfIntegral = arithmeticService.DoNinesComplement(negativeNumberString.IntegralPartDigitList);


            // sum = positive + 9's complement
            List<int> fraction = arithmeticService.AdditionOfFractionalPart(positiveNumberString.FractionalPartDigitList, ncOfFraction, ref carry);
            List<int> integral = arithmeticService.AdditionOfIntegralPart(positiveNumberString.IntegralPartDigitList, ncOfIntegral, ref carry);

            if (carry > 0)
            {
                // add carry with integral, means result is possitive

                integral = arithmeticService.AdditionOfIntegralPart(integral, new List<int>(), ref carry);
                if (fraction.Count > 0)
                    fractionString = "." + arithmeticService.ListIntToString(fraction).TrimEnd('0');

                return arithmeticService.ListIntToString(integral).TrimStart('0') + fractionString;
            }
            else
            {
                //  9's complement on result, this is the final result and result is a Negative Number

                ncOfFraction = arithmeticService.DoNinesComplement(fraction);
                ncOfIntegral = arithmeticService.DoNinesComplement(integral);
                if (ncOfFraction.Count > 0)
                    fractionString = "." + arithmeticService.ListIntToString(ncOfFraction).TrimEnd('0');

                return "-" + arithmeticService.ListIntToString(ncOfIntegral).TrimStart('0') + fractionString;

            }
        }
    }
}
