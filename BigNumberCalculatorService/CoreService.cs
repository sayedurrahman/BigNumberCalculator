using BigNumberCalculator.Core.SummationService;
using BigNumberCalculator.Repository;
using BigNumberCalculator.Repository.Models;

namespace BigNumberCalculator.Core
{
    public class CoreService : ICoreService
    {
        private readonly IGenericRepository<Calculation> calculationRepository;
        private readonly UserRepository userRepository;
        public CoreService(IGenericRepository<Calculation> calculationRepository, UserRepository userRepository)
        {
            this.calculationRepository = calculationRepository;
            this.userRepository = userRepository;
        }

        public void CalculateAndStore(string firstNumber, string secondNumber, string userName)
        {
            string result = CalculateSum(firstNumber, secondNumber);
            User user = GetUserByUserName(userName);
            Calculation calculation = new Calculation { User = user, BigNumber1 = firstNumber, BigNumber2 = secondNumber, Sum = result };
            calculationRepository.Insert(calculation);
        }

        public User GetUserByUserName(string userName)
        {
            var user = userRepository.GetUserByName(userName);
            if (user == null)
            {
                user = new User { UserName = userName };
            }

            return user;
        }

        public string CalculateSum(string firstNumber, string secondNumber)
        {
            string result = new SummationFactory(firstNumber, secondNumber).DoTheSum();


            if (string.IsNullOrWhiteSpace(result) || result == "-")
                result = "0";

            return result;
        }
    }
}
