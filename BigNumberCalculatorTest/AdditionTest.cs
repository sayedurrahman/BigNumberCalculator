using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace BigNumberCalculatorTest
{
    public class AdditionTest
    {
        [Theory]
        [MemberData(nameof(IntegralTestData))]
        public void IntegralTest(List<int> firstList, List<int> secondList, int carry, string result)
        {
            string testResult = TestHelper.ArithmeticService.AdditionOfIntegralPart(firstList, secondList, carry);
            Assert.Equal(result, testResult);
        }

        [Theory]
        [MemberData(nameof(FractionalTestData))]
        public void FractionalTest(List<int> firstList, List<int> secondList, string result)
        {
            int carry = 0;
            string testResult = TestHelper.ArithmeticService.AdditionOfFractionalPart(firstList, secondList, out carry);
            Assert.Equal(result, testResult);
        }

        [Theory]
        [MemberData(nameof(FractionalTestDataForCarry))]
        public void FractionalTestForCarry(List<int> firstList, List<int> secondList, int carryResult)
        {
            int carry = 0;
            TestHelper.ArithmeticService.AdditionOfFractionalPart(firstList, secondList, out carry);
            Assert.Equal(carryResult, carry);
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
            new object[] { new List<int> { 5, 5, 5, 5 }, new List<int> { 5, 5, 5, 5 }, 0 , "11110" },
            new object[] { new List<int> { 5, 5, 5, 5 }, new List<int> { 5, 5, 5, 5 }, 1 , "11111" },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 1 }, 0 , "100000000" },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 1 }, 2 , "100000002" },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 1 }, 0 , "10000000000000000000000000000000" },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 1 }, 5 , "10000000000000000000000000000005" },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, 0 , "199999999999999999998" },
            new object[] { new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, 5 , "200000000000000000003" },
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
    }
}
