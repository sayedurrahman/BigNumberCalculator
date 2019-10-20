using System;
using System.Collections.Generic;
using System.Text;
using BigNumberCalculator.Core.ArithmeticOparationService;
using BigNumberCalculator.Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BigNumberCalculator.Core.SummationService
{
    public class TwoPositiveNumberService : ITwoNumberSummation
    {
        private readonly IArithmeticService arithmeticService;
        public TwoPositiveNumberService()
        {
            arithmeticService = SummationHelper.ArithmeticService;
        }

        public string DoTheSum(BigNumberString firstNumberString, BigNumberString secondNumberString)
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
    }
}
