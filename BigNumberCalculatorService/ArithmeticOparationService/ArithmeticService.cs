using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigNumberCalculator.Core.ArithmeticOparationService
{
    public class ArithmeticService : IArithmeticService
    {
        public List<int> AdditionOfIntegralPart(List<int> firstList, List<int> secondList, ref int carry)
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

            if (firstList.Count > secondList.Count)
            {
                foreach (var i in Enumerable.Range(0, firstList.Count - secondList.Count))
                {
                    secondList.Insert(0, 0);
                }
            }
            else if (firstList.Count < secondList.Count)
            {
                foreach (var i in Enumerable.Range(0, secondList.Count - firstList.Count))
                {
                    firstList.Insert(0, 0);
                }
            }

            firstList.Reverse();
            secondList.Reverse();
            // we have to reverse both array because list.zip works from left to right

            // can not use same ref carry in to another ref carry. compile error. so using local variable
            int localCarry = carry;
            List<int> result = firstList.Zip(secondList, (i, j) => DigitSum(i, j, ref localCarry)).ToList();
            result.Reverse();

            carry = localCarry;
            return result;
        }

        public List<int> AdditionOfFractionalPart(List<int> firstList, List<int> secondList, ref int carry)
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

            if (firstList.Count > secondList.Count)
            {
                foreach (var i in Enumerable.Range(0, firstList.Count - secondList.Count))
                {
                    secondList.Add(0);
                }
            }
            else if (firstList.Count < secondList.Count)
            {
                foreach (var i in Enumerable.Range(0, secondList.Count - firstList.Count))
                {
                    firstList.Add(0);
                }
            }

            firstList.Reverse();
            secondList.Reverse();
            // we have to reverse both array because list.zip works from left to right

            // can not use same ref carry in to another ref carry. compile error. so using local variable
            int localCarry = 0;
            List<int> result = firstList.Zip(secondList, (i, j) => DigitSum(i, j, ref localCarry)).ToList();
            result.Reverse();
            carry = localCarry;
            return result;
        }

        public List<int> DoNinesComplement(List<int> input)
        {
            List<int> ninesComplement = new List<int>();
            input.ForEach(x => ninesComplement.Add(9 - x));
            return ninesComplement;
        }

        public string ListIntToString(List<int> input)
        {
            StringBuilder sb = new StringBuilder();
            input.ForEach(x => sb.Append(x.ToString()));
            return sb.ToString();
        }

        private int DigitSum(int i, int j, ref int carry)
        {
            int sum = i + j + carry;
            carry = sum / 10;
            return sum % 10;
        }
    }
}
