using System;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculatorService
{
    interface IArithmeticService
    {
        string AdditionOfFractionalPart(List<int> firstArray, List<int> secondArray);
        string AdditionOfIntegralPart(List<int> firstArray, List<int> secondArray,int carry);
    }
}
