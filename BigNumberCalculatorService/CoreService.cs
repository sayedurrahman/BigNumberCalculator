using BigNumberCalculator.Core.SummationService;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculator.Core
{
    public class CoreService : ICoreService
    {
        public string CalculateSum(string firstNumber, string secondNumber)
        {
            string result = new SummationFactory(firstNumber, secondNumber).DoTheSum();


            if (string.IsNullOrWhiteSpace(result) || result == "-")
                result = "0";

            return result;
        }
    }
}
