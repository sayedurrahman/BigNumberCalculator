using System;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculator.Core.ArithmeticOparationService
{
    public interface IArithmeticService
    {
        /// <summary>
        /// digit by digit sum of two list of int for integral
        /// </summary>
        /// <param name="firstList">first number in list of digits</param>
        /// <param name="secondList">second number in list of digits</param>
        /// <param name="carry">(if any) from fractional part, set for further use</param>
        /// <returns>list of int, each item represents sum of items of same position from each list</returns>
        List<int> AdditionOfIntegralPart(List<int> firstList, List<int> secondList, ref int carry);

        /// <summary>
        /// digit by digit sum of two list of int for fractional
        /// </summary>
        /// <param name="firstArray">first number in list of digits</param>
        /// <param name="secondArray">second number in list of digits</param>
        /// <param name="carry">(if any) set for further use</param>
        /// <returns>list of int, each item represents sum of items of same position from each list</returns>
        List<int> AdditionOfFractionalPart(List<int> firstArray, List<int> secondArray, ref int carry);

        /// <summary>
        /// Creates 9's compliment
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        List<int> DoNinesComplement(List<int> input);

        /// <summary>
        /// Convert input int list to string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string ListIntToString(List<int> input);
        
        
    }
}
