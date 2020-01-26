using Exercises.Models;
using Exercises.SessionExcerises;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.UnitTests
{
    [TestClass]
    public class HomeworkWeek2
    {
        [TestMethod]
        public void ReturnYCoord_Returns_YCoordAndProvesValueType()
        {
            int initialXCoord = 10;
            int numberToAdd = 12;
            int returnedYCoord = ValueTypeOperations.ReturnYCoord(initialXCoord, numberToAdd);

            int expectedYValue = initialXCoord + numberToAdd;

            Assert.AreEqual(returnedYCoord, expectedYValue);
            Assert.AreEqual(initialXCoord, 10);
        }

        [TestMethod]
        public void ReturnPerson2Age_Returns_SecondPersonAndProvesReferenceType()
        {
            PersonModel initialPerson1 = new PersonModel();
            PersonModel returnedPerson2 = new PersonModel();
            
            initialPerson1.Age = 20;
            int newPerson1Age = 25;

            returnedPerson2.Age = ReferenceTypeOperations.ReturnPerson2Age(initialPerson1, newPerson1Age);

            Assert.AreEqual(initialPerson1.Age, 25);
            Assert.AreEqual(returnedPerson2.Age, 25);
        }
    }
}
