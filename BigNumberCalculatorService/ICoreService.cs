using BigNumberCalculator.Core.Models;
using System.Collections.Generic;

namespace BigNumberCalculator.Core
{
    public interface ICoreService
    {
        List<UserCalculation> GetAllCalculation();
        string CalculateSum(string firstNumber, string secondNumber);
        void CalculateAndStore(string firstNumber, string secondNumber, string userName);
    }
}