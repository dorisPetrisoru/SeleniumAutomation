using Exercises.Models;
using Exercises.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.UnitTests
{
    [TestClass]
    public class Week4
    {
        [TestMethod]
        public void AddStudentsToCourse_AddsStudentsToSelectedCourse()
        {
            CourseModel courseModel = new CourseModel
            {
                Name = "Test Automation",
                StartDate = DateTime.Now.AddMonths(1),
                EndDate = DateTime.Now.AddYears(1),
                Students = new List<StudentModel>()
            };

            StudentModel studentModel = new StudentModel
            {
                FirstName = "First",
                LastName = "Student"
            };

            List<StudentModel> studentModelList = new List<StudentModel>{studentModel};

            CourseService courseService = new CourseService();

            courseService.AddStudentsToCourse(courseModel, studentModelList);

            var studentsInList = courseModel.Students.Any(student => student.FirstName == "First" 
                                                && student.LastName == "Student");
            Assert.IsTrue(studentsInList);

        }
    }
}
