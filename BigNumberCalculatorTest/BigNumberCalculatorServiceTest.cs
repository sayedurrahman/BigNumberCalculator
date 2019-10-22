using BigNumberCalculator.Core.SummationService;
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
        [MemberData(nameof(DataPositiveAndDecimal))]
        [MemberData(nameof(DataNegativeAndDecimal))]
        [MemberData(nameof(DataMixDecimal))] 
        public void DoSumTest(string firstNumber, string secondNumber, string result)
        {
            string actualResult = TestHelper.CoreService.CalculateSum(firstNumber, secondNumber);
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

        public static IEnumerable<object[]> DataPositiveAndDecimal =>
        new List<object[]>
        {
            new object[] { "0.4","0.4", "0.8" },
            new object[] { "5.5","5.5", "11.0" },
            new object[] { "10.2","10.7", "20.9" },
            new object[] { "10.9","1.9", "12.8" },
            new object[] { "9.99","1.1", "11.09" },
            new object[] { "4.44","44.4", "48.84" },
            new object[] { "99999999.99999999","0", "99999999.99999999" },
            new object[] { "99999999.99999999","1", "100000000.99999999" },
            new object[] { "55.55","9999.9999999999999999", "10055.5499999999999999" },
        };

        public static IEnumerable<object[]> DataNegativeAndDecimal =>
        new List<object[]>
        {
            new object[] { "-0.4","-0.4", "-0.8" },
            new object[] { "-5.5","-5.5", "-11.0" },
            new object[] { "-10.2","-10.7", "-20.9" },
            new object[] { "-10.9","-1.9", "-12.8" },
            new object[] { "-9.99","-1.1", "-11.09" },
            new object[] { "-4.44","-44.4", "-48.84" },
            new object[] { "-99999999.99999999","0", "-99999999.99999999" },
            new object[] { "-99999999.99999999","-1", "-100000000.99999999" },
            new object[] { "-55.55","-9999.9999999999999999", "-10055.5499999999999999" },
        };

        public static IEnumerable<object[]> DataMixDecimal =>
        new List<object[]>
        {
            new object[] { "4.9", "-23456.23456789", "-23451.33456789" },
            new object[] { "-9.1111111111","5.8989898989898989898", "-3.2121212121101010102" },
            new object[] { "9999999999999999.49812309481038410238","-1.78872349813749832", "9999999999999997.70939959667288578238" },
            new object[] { "5.55","-11.1", "-5.55" },
            new object[] { "-3333.3","3", "-3330.3" },
            new object[] { "5454545454.545454545","-72727272727272.727272727272727272727272727", "-72721818181818.181818182272727272727272727" },
        };
    }
}
