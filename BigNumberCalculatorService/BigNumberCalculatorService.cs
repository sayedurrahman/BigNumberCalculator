using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigNumberCalculatorService
{
    public class BigNumberCalculatorService: IBigNumberCalculatorService
    {
        private readonly IArithmeticService arithmeticService;
        public BigNumberCalculatorService(IArithmeticService arithmeticService)
        {
            this.arithmeticService = arithmeticService;
        }

        public string DoSum(string firstNumber, string secondNumber)
        {
            var firstBigNumberString = new BigNumberString(firstNumber);
            var secondBigNumberString = new BigNumberString(secondNumber);
            return DoTheMath(firstBigNumberString, secondBigNumberString);
        }

        private string DoTheMath(BigNumberString firstBigNumberString, BigNumberString secondBigNumberString)
        {
            string result = string.Empty;
            if (firstBigNumberString.IsNegative && secondBigNumberString.IsNegative)
            {
                // means both are negative
                result = DoSumTwoNegativeNumber(firstBigNumberString, secondBigNumberString);
            }
            else if (!firstBigNumberString.IsNegative && !secondBigNumberString.IsNegative)
            {
                // means both are positive
                result = DoSumTwoPositiveNumber(firstBigNumberString, secondBigNumberString);
            }
            else
            {
                // one is positive one is negative
                if (firstBigNumberString.IsNegative)
                    result = DoSumOnePositiveOneNegativeNumber(secondBigNumberString, firstBigNumberString);
                else
                    result = DoSumOnePositiveOneNegativeNumber(firstBigNumberString, secondBigNumberString);
            }

            if (string.IsNullOrWhiteSpace(result) || result == "-")
                result = "0";

            return result;
        }

        private string DoSumTwoPositiveNumber(BigNumberString firstNumberString, BigNumberString secondNumberString)
        {
            int carry = 0;
            string fractionString = string.Empty;
            List<int> fraction = arithmeticService.AdditionOfFractionalPart(firstNumberString.FractionalPartDigitList, secondNumberString.FractionalPartDigitList, ref carry);
            List<int> integral = arithmeticService.AdditionOfIntegralPart(firstNumberString.IntegralPartDigitList, secondNumberString.IntegralPartDigitList, ref carry);

            // we should add carry, if carry is greater than zero
            if (carry > 0)
                integral.Insert(0, carry);

            if (fraction.Count > 0)
                fractionString = "." + arithmeticService.ListIntToString(fraction);

            return arithmeticService.ListIntToString(integral) + fractionString;
        }

        private string DoSumTwoNegativeNumber(BigNumberString firstNumberString, BigNumberString secondNumberString)
        {
            /*
             * Sum of two negative number means sum of those number and minus sign in the beginning
             * */
            return "-" + DoSumTwoPositiveNumber(firstNumberString, secondNumberString);
        }

        private string DoSumOnePositiveOneNegativeNumber(BigNumberString positiveNumberString, BigNumberString negativeNumberString)
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

            // before we do 9's complement of negative number we must check if it has digit equals to or greater then positive counter part
            // else it end up wrong answer
            // if it is fractional add zero at end
            // if it is integral add zero at beginning
            if (positiveNumberString.FractionalPartDigitList.Count> negativeNumberString.FractionalPartDigitList.Count)
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
