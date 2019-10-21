namespace BigNumberCalculator.Core
{
    public interface ICoreService
    {
        string CalculateSum(string firstNumber, string secondNumber);
        void CalculateAndStore(string firstNumber, string secondNumber, string userName);
    }
}