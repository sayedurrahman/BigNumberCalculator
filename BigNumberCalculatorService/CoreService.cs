using BigNumberCalculator.Core.Models;
using BigNumberCalculator.Core.SummationService;
using BigNumberCalculator.Repository;
using BigNumberCalculator.Repository.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BigNumberCalculator.Core
{
    public class CoreService : ICoreService
    {
        private readonly IGenericRepository<Calculation> calculationRepository;
        private readonly UserRepository userRepository;
        private readonly UserCalculatorRepository userCalculatorRepository;
        public CoreService(IGenericRepository<Calculation> calculationRepository, UserRepository userRepository, UserCalculatorRepository userCalculatorRepository)
        {
            this.calculationRepository = calculationRepository;
            this.userRepository = userRepository;
            this.userCalculatorRepository = userCalculatorRepository;
        }

        public List<UserCalculation> GetAllCalculation()
        {
            return userCalculatorRepository.GetAllCalculation()
                .Select(x => new UserCalculation
                {
                    UserName = x.User.UserName,
                    CalculationDate = x.CalculationDate,
                    BigNumber1 = x.BigNumber1,
                    BigNumber2 = x.BigNumber2,
                    Sum = x.Sum
                }).ToList();
        }

        public void CalculateAndStore(string firstNumber, string secondNumber, string userName)
        {
            string result = CalculateSum(firstNumber, secondNumber);
            User user = GetUserByUserName(userName);
            Calculation calculation = new Calculation { User = user, BigNumber1 = firstNumber, BigNumber2 = secondNumber, Sum = result, CalculationDate = System.DateTime.Now };
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
