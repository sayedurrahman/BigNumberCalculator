using System;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculatorService
{
    public interface IArithmeticService
    {
        /// <summary>
        /// digit by digit sum of two list of int for integral
        /// </summary>
        /// <param name="firstArray">first number in list of digits</param>
        /// <param name="secondArray">second number in list of digits</param>
        /// <param name="carry">(if any) from fractional part</param>
        /// <returns>Sum as string</returns>
        string AdditionOfIntegralPart(List<int> firstArray, List<int> secondArray, int carry);

        /// <summary>
        /// digit by digit sum of two list of int for fractional
        /// </summary>
        /// <param name="firstArray">first number in list of digits</param>
        /// <param name="secondArray">second number in list of digits</param>
        /// <param name="carry">(if any) set for further use</param>
        /// <returns></returns>
        string AdditionOfFractionalPart(List<int> firstArray, List<int> secondArray, out int carry);
    }
}
