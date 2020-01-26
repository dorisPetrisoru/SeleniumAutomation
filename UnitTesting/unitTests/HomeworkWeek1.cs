using Exercises.SessionExcerises;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.UnitTests
{
    [TestClass]
    public class HomeworkWeek1
    {
        [TestMethod]
        public void IsLeapYear_returnsTrue_divisibleBy4_notBy100()
        {
            int yearToCheck = 2016;

            bool actualResult = LeapYearCalculator.IsLeapYear(yearToCheck);

            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void IsLeapYear_returnsTrue_divisibleBy400()
        {
            int yearToCheck = 2020;

            bool actualResult = LeapYearCalculator.IsLeapYear(yearToCheck);

            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void IsLeapYear_returnsFalse_divisibleBy100_notBy400()
        {
            int yearToCheck = 1900;

            bool actualResult = LeapYearCalculator.IsLeapYear(yearToCheck);

            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void IsLeapYear_returnsFalse_notDivisibleBy4()
        {
            int yearToCheck = 2019;

            bool actualResult = LeapYearCalculator.IsLeapYear(yearToCheck);

            Assert.IsFalse(actualResult);
        }
    }
}
