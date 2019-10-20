using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BigNumberCalculatorTest
{
    public class BigNumberCalculatorServiceTest
    {
        [Theory]
        [MemberData(nameof(DataPositiveOnly))]
        [MemberData(nameof(DataNegativeOnly))]
        [MemberData(nameof(DataMix))]
        public void DoSumTest(string firstNumber, string secondNumber, string result)
        {
            string actualResult = TestHelper.BigNumberCalculatorService.DoSum(firstNumber, secondNumber);
            Assert.Equal(result, actualResult);
        }

        public static IEnumerable<object[]> DataPositiveOnly =>
        new List<object[]>
        {
            new object[] { "4","4", "8" },
            new object[] { "5","5", "10" },
            new object[] { "10","10", "20" },
            new object[] { "10","1", "11" },
            new object[] { "999","1", "1000" },
            new object[] { "444","444", "888" },
            new object[] { "9999999999999999","0", "9999999999999999" },
            new object[] { "9999999999999999","1", "10000000000000000" },
            new object[] { "5555","99999999999999999999", "100000000000000005554" },
        };

        public static IEnumerable<object[]> DataNegativeOnly =>
        new List<object[]>
        {
            new object[] { "-4","-4", "-8" },
            new object[] { "-5","-5", "-10" },
            new object[] { "-10","-10", "-20" },
            new object[] { "-10","-1", "-11" },
            new object[] { "-999","-1", "-1000" },
            new object[] { "-444","-444", "-888" },
            new object[] { "-9999999999999999","-0", "-9999999999999999" },
            new object[] { "-9999999999999999","-1", "-10000000000000000" },
            new object[] { "-5555","-99999999999999999999", "-100000000000000005554" },
            new object[] { "-555","-111", "-666" },
        };

        public static IEnumerable<object[]> DataMix =>
        new List<object[]>
        {
            new object[] { "4","-4", "0" },
            new object[] { "-5","5", "0" },
            new object[] { "9999999999999999","-1", "9999999999999998" },
            new object[] { "555","-111", "444" },
            new object[] { "-456","456", "0" },
            new object[] { "-33333","3", "-33330" },
            new object[] { "-100000","1", "-99999" },
            new object[] { "5454545454545454545","-72727272727272727272727272727272727272727", "-72727272727272727272721818181818181818182" },
        };
    }
}
