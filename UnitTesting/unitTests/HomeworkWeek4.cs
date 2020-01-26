
using Exercises.Models;
using Exercises.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests.UnitTests
{
    [TestClass]
    public class HomeworkWeek4
    {
        private CourseService courseService;
        public HomeworkWeek4()
        {
            courseService = new CourseService();
        }

        [TestMethod]
        public void ModifyCourseDates_AddsNewCourseBeginAndEndDates()
        {
            CourseModel automationCourse = new CourseModel
            {
                Name = "Test Automation",
                Students = new List<StudentModel>()
            };

            DateTime startDate = DateTime.Now.AddDays(15);
            DateTime endDate = DateTime.Now.AddMonths(24);

            courseService.ModifyCourseDates(automationCourse, startDate, endDate);

            Assert.IsTrue(automationCourse.StartDate.Equals(startDate));
            Assert.IsTrue(automationCourse.EndDate.Equals(endDate));
        }
    }
}
