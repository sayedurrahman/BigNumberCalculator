using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculator.Core.Models
{
    /// <summary>
    /// This class represents a very large number
    /// </summary>
    public class BigNumberString
    {
        /// <summary>
        /// Splits the input string into integralPart (list of int) and FractionalPart (list of int)
        /// also checks if it is a negative number
        /// </summary>
        /// <param name="bigNumber"></param>
        public BigNumberString(string bigNumber)
        {
            IsNegative = bigNumber.StartsWith('-');

            // This will remove minus sign (if any) at the beginning and also split the number in integral and fractional part
            // first item of the array is integral part and second item (if any) of the array is fractional part
            string[] numberSegment = bigNumber.Split(new char[] { '-', '.' }, System.StringSplitOptions.RemoveEmptyEntries);

            if (numberSegment.Length > 0)
            {
                IntegralPartDigitList = numberSegment[0].Select(x => int.Parse(x.ToString())).ToList();
            }

            if (numberSegment.Length > 1)
            {
                FractionalPartDigitList = numberSegment[1].Select(x => int.Parse(x.ToString())).ToList();
            }
        }

        public readonly List<int> IntegralPartDigitList = new List<int>();
        public readonly List<int> FractionalPartDigitList = new List<int>();
        public readonly bool IsNegative;
    }
}
