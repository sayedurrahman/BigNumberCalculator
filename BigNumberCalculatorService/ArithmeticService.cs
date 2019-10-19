using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculatorService
{
    public class ArithmeticService : IArithmeticService
    {
        public string AdditionOfIntegralPart(List<int> firstArray, List<int> secondArray, int carry)
        {
            /*
             * add zeros at the beginning in the smaller arrar (if arrays are not in same size) to crate same size array
             * Use array.zip function to add digits
             * 
             * e.g.
             * 12545 + 545 = 12545 + 00545
             * input: 12545 and 545
             * 12545
             * 00545
             * ------
             * 13090
             * */

            if (firstArray.Count > secondArray.Count)
            {
                foreach (var i in Enumerable.Range(0, firstArray.Count - secondArray.Count))
                {
                    secondArray.Insert(0, 0);
                }
            }
            else if (firstArray.Count < secondArray.Count)
            {
                foreach (var i in Enumerable.Range(0, secondArray.Count - firstArray.Count))
                {
                    firstArray.Insert(0, 0);
                }
            }

            firstArray.Reverse();
            secondArray.Reverse();
            // we have to reverse both array because list.zip works from left to right

            List<int> result = firstArray.Zip(secondArray, (i, j) => DigitSum(i, j, ref carry)).ToList();

            // we should add carry, if carry is greater than zero
            if (carry > 0)
                result.Add(carry);

            result.Reverse();
            return ListIntToString(result);
        }

        public string AdditionOfFractionalPart(List<int> firstArray, List<int> secondArray, out int carry)
        {
            /*
             * add zeros at the end in the smaller list (if list are not in same size) to create same size list
             * Use list.zip function to add digits
             * 
             * e.g.
             * x.12545 + y.345 = x.12545 + y.34500
             * input: 12545 and 345
             * 12545
             * 34500
             * ------
             * 47045
             * */

            if (firstArray.Count > secondArray.Count)
            {
                foreach (var i in Enumerable.Range(0, firstArray.Count - secondArray.Count))
                {
                    secondArray.Add(0);
                }
            }
            else if (firstArray.Count < secondArray.Count)
            {
                foreach (var i in Enumerable.Range(0, secondArray.Count - firstArray.Count))
                {
                    firstArray.Add(0);
                }
            }

            firstArray.Reverse();
            secondArray.Reverse();
            // we have to reverse both array because list.zip works from left to right

            int localCarry = 0;
            List<int> result = firstArray.Zip(secondArray, (i, j) => DigitSum(i, j, ref localCarry)).ToList();
            result.Reverse();
            carry = localCarry;
            return ListIntToString(result);
        }

        private int DigitSum(int i, int j, ref int carry)
        {
            int sum = i + j + carry;
            carry = sum / 10;
            return sum % 10;
        }

        private string ListIntToString(List<int> input)
        {
            StringBuilder sb = new StringBuilder();
            input.ForEach(x => sb.Append(x.ToString()));
            return sb.ToString();
        }
    }
}
