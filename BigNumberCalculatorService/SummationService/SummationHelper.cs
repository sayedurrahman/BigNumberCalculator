using BigNumberCalculator.Core.ArithmeticOparationService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculator.Core.SummationService
{
    public static class SummationHelper
    {
        public readonly static IArithmeticService ArithmeticService;
        static SummationHelper()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IArithmeticService, ArithmeticService>();

            var serviceProvider = services.BuildServiceProvider();
            ArithmeticService = serviceProvider.GetService<IArithmeticService>();
        }
    }
}
