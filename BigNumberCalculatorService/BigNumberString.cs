using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculatorService
{
    /// <summary>
    /// This class represents a very large number
    /// </summary>
    public class BigNumberString
    {
        /// <summary>
        /// Splits the input string into integralPartArray(int) and FractionalPartArray(int)
        /// also checks if it is a negative number and position of decimal point
        /// </summary>
        /// <param name="bigNumber"></param>
        public BigNumberString(string bigNumber)
        {
            IsNegative = bigNumber.StartsWith('-');

            // This will remove minus sign (if any) at the beginning and also split the number in integral and fractional part
            // first item of the array is integral part and second item (if any) of the array is fractional part
            string[] numberSegment= bigNumber.Split(new char[] { '-', '.' }, System.StringSplitOptions.RemoveEmptyEntries);

            if (numberSegment.Length > 0)
            {
                IntegralPartArray = numberSegment[0].Select(x => (int)x).ToList();
            }

            if (numberSegment.Length > 1)
            {
                FractionalPartArray = numberSegment[1].Select(x => (int)x).ToList();
            }
        }

        public List<int> IntegralPartArray { get; private set; }
        public List<int> FractionalPartArray { get; private set; }
        public bool IsNegative { get; private set; }
    }
}
