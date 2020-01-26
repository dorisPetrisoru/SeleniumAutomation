using Exercises.Models;
using Exercises.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.UnitTests
{
    [TestClass]
    public class HomeworkWeek5
    {
        int beginTeachingYear;
        TeacherModel teacher;
        TeacherService teacherService;
        
        [TestInitialize]
         public void init()
        {
            teacher = new TeacherModel
            {
                FullName = "Petrisoru Doris",
                Age = 24
            };

            teacherService = new TeacherService();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), 
            "Teaching experience calculation with a begin teaching year that is set in the future should throw ArgumentException")]
        public void CalculateTeachingExperience_NegativeScenario_Solution1_BeginYearIsInTheFuture()
        {
            beginTeachingYear = 2020;

            teacherService.CalculateTeachingExperience(teacher, beginTeachingYear);
        }

        [TestMethod]
        public void CalculateTeachingExperience_NegativeScenario_Solution2_BeginYearIsInTheFuture()
        {
            beginTeachingYear = 2020;

            Assert.ThrowsException<ArgumentException>(
                () => teacherService.CalculateTeachingExperience(teacher, beginTeachingYear));
        }

        [TestMethod]
        public void CalculateTeachingExperience_GivesCorrectNumberOfYears()
        {
            beginTeachingYear = 2017;

            teacherService.CalculateTeachingExperience(teacher, beginTeachingYear);

            Assert.IsTrue(teacher.TeachingExperience.Equals(DateTime.Now.Year - beginTeachingYear));
        }
    }
}





