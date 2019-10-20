﻿using BigNumberCalculator.Core;
using BigNumberCalculator.Core.ArithmeticOparationService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculatorTest
{
    public static class TestHelper
    {
        public readonly static IArithmeticService ArithmeticService;
        public readonly static ICoreService CoreService;
        static TestHelper()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IArithmeticService, ArithmeticService>();
            services.AddSingleton<ICoreService, CoreService>();

            var serviceProvider = services.BuildServiceProvider();
            ArithmeticService = serviceProvider.GetService<IArithmeticService>();
            CoreService = serviceProvider.GetService<ICoreService>();
        }
    }
}
