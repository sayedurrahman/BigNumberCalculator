using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace BigNumberCalculatorTest
{
    public class ArithmeticServiceTest
    {
        [Theory]
        [MemberData(nameof(IntegralTestData))]
        public void IntegralTest(List<int> firstList, List<int> secondList, int carry, string result)
        {
            int localCarry = carry;
            List<int> resultIntList = TestHelper.ArithmeticService.AdditionOfIntegralPart(firstList, secondList, ref localCarry);
            var testResult = TestHelper.ArithmeticService.ListIntToString(resultIntList);
            Assert.Equal(result, testResult);
        }

        [Theory]
        [MemberData(nameof(FractionalTestData))]
        public void FractionalTest(List<int> firstList, List<int> secondList, string result)
        {
            int carry = 0;
            List<int> resultIntList = TestHelper.ArithmeticService.AdditionOfFractionalPart(firstList, secondList, ref carry);
            var testResult = TestHelper.ArithmeticService.ListIntToString(resultIntList);
            Assert.Equal(result, testResult);
        }

        [Theory]
        [MemberData(nameof(FractionalTestDataForCarry))]
        public void FractionalTestForCarry(List<int> firstList, List<int> secondList, int carryResult)
        {
            int carry = 0;
            TestHelper.ArithmeticService.AdditionOfFractionalPart(firstList, secondList, ref carry);
            Assert.Equal(carryResult, carry);
        }

        [Theory]
        [MemberData(nameof(NinesComplementData))]
        public void NinesComplementTest(List<int> list, string result)
        {
            var nC = TestHelper.ArithmeticService.DoNinesComplement(list);
            string ncString= TestHelper.ArithmeticService.ListIntToString(nC);
            Assert.Equal(ncString, result);
        }

        public static IEnumerable<object[]> IntegralTestData =>
        new List<object[]>
        {
            new object[] { new List<int> { 0 }, new List<int> { 0 }, 0 , "0" },
            new object[] { new List<int> { 0 }, new List<int> { 0 }, 1 , "1" },
            new object[] { new List<int> { 1 }, new List<int> { 1 }, 0 , "2" },
            new object[] { new List<int> { 1 }, new List<int> { 1 }, 1 , "3" },
            new object[] { new List<int> { 1 , 1 }, new List<int> { 1 }, 0 , "12" },
            new object[] { new List<int> { 1 , 1 }, new List<int> { 1 }, 1 , "13" },
            new object[] { new List<int> { 1 , 1 }, new List<int> { 1 , 1 }, 0 , "22" },
            new object[] { new List<int> { 1 , 1 }, new List<int> { 1 , 1 }, 1 , "23" },
            new object[] { new List<int> { 5, 5, 5, 5 }, new List<int> { 5, 5, 5, 5 }, 0 , "1110" },
            new object[] { new List<int> { 5, 5, 5, 5 }, new List<int> { 5, 5, 5, 5 }, 1 , "1111" },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 1 }, 0 , "00000000" },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 1 }, 2 , "00000002" },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 1 }, 0 , "0000000000000000000000000000000" },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 1 }, 5 , "0000000000000000000000000000005" },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, 0 , "99999999999999999998" },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, 5 , "00000000000000000003" },
        };

        public static IEnumerable<object[]> FractionalTestData =>
        new List<object[]>
        {
            new object[] { new List<int> { 0 }, new List<int> { 0 }, "0" },
            new object[] { new List<int> { 1 }, new List<int> { 1 }, "2" },
            new object[] { new List<int> { 1 , 1 }, new List<int> { 1 }, "21" },
            new object[] { new List<int> { 1 , 1 }, new List<int> { 1 , 1 }, "22" },
            new object[] { new List<int> { 5, 5, 5, 5 }, new List<int> { 5, 5, 5, 5 }, "1110" },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 1 }, "09999999" },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 1 }, "0999999999999999999999999999999" },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 },  "99999999999999999998" },
        };

        public static IEnumerable<object[]> FractionalTestDataForCarry =>
        new List<object[]>
        {
            new object[] { new List<int> { 0 }, new List<int> { 0 }, 0 },
            new object[] { new List<int> { 1 }, new List<int> { 1 }, 0 },
            new object[] { new List<int> { 1 , 1 }, new List<int> { 1 }, 0 },
            new object[] { new List<int> { 1 , 1 }, new List<int> { 1 , 1 }, 0 },
            new object[] { new List<int> { 5, 5, 5, 5 }, new List<int> { 5, 5, 5, 5 }, 1 },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 1 }, 1 },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 1 }, 1 },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 },  1 },
        };

        public static IEnumerable<object[]> NinesComplementData =>
        new List<object[]>
        {
            new object[] { new List<int> { 0 }, "9" },
            new object[] { new List<int> { 1 }, "8" },
            new object[] { new List<int> { 1 , 1 },"88" },
            new object[] { new List<int> { 5, 5, 5, 5 },  "4444" },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9 }, "00000000" },
            new object[] { new List<int> { 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 },  "11111111111111111111" },
        };
    }
}
