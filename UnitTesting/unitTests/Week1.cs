using Exercises.SessionExcerises;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.UnitTests
{
    [TestClass]
    public class Week1
    {
        [TestMethod]
        public void WelcomeUser_Returns_enteredName()
        {
            var actualMessage = GreetingHelper.GetGreetingMessage("doris");
            var expectedMessage = "Hi doris!";

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void AddToNumber_Returns_expectedResult()
        {
            var actualSum = MathOperations.GetSum(1,3);
            var expectedSum = 4;

            Assert.AreEqual(expectedSum, actualSum);
        }
    }
}
