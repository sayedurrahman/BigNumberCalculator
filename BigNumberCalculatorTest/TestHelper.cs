using BigNumberCalculatorService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculatorTest
{
    public static class TestHelper
    {
        public readonly static IArithmeticService ArithmeticService;
        public readonly static IBigNumberService BigNumberService;
        static TestHelper()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IArithmeticService, ArithmeticService>();
            services.AddSingleton<IBigNumberService, BigNumberCalculatorService.BigNumberService>();

            var serviceProvider = services.BuildServiceProvider();
            ArithmeticService = serviceProvider.GetService<IArithmeticService>();
            BigNumberService = serviceProvider.GetService<IBigNumberService>();
        }
    }
}
