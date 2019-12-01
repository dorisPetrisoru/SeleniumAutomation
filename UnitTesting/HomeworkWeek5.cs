﻿using Exercises.Models;
using Exercises.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTesting
{
    [TestClass]
    public class HomeworkWeek5
    {
        int beginTeachingYear;
        TeacherModel teacher;
        TeacherService teacherService;

         public HomeworkWeek5()
        {
            teacher = new TeacherModel
            {
                FullName = "Petrisoru Doris",
            };

            teacherService = new TeacherService();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), 
            "Teaching experience calculation with a begin teaching year that is set in the future should throw ArgumentException")]
        public void CalculateTeachingExperience_NegativeScenario_BeginYearIsInTheFuture()
        {
            beginTeachingYear = 2020;

            teacherService.CalculateTeachingExperience(teacher, beginTeachingYear);
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





