using Exercises.Models;
using Exercises.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.UnitTests
{
    [TestClass]
    public class HomeworkWeek6
    {
        private string fullName = "";
        private StudentServices studentService;
        private StudentModel student;
        public HomeworkWeek6()
        {
            studentService = new StudentServices();
            student = new StudentModel();
        }

        [TestCategory("Positive Scenario")]
        [TestMethod]
        public void GetStudentLastNameAndFirstName_ReturnsLastNameFromFullName()
        {
            fullName = "Prenume Nume";
            student.FullName = fullName;

            student.LastName = studentService.GetStudentLastName(student);
            student.FirstName = studentService.GetStudentFirstName(student);

            Assert.IsTrue(student.LastName.Equals("Nume") && student.FirstName.Equals("Prenume"));
        }

        [TestCategory("Negative Scenario")]
        [TestMethod]
        public void GetStudentLastNameAndFirstNam_ReturnsArgumentException()
        {
            student.FullName = null;

            Assert.ThrowsException<ArgumentException>(() => studentService.GetStudentLastName(student));
            Assert.ThrowsException<ArgumentException>(() => studentService.GetStudentFirstName(student));
        }
    }
}
