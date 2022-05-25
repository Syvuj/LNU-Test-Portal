using Business_Layer.Services;
using Business_Layer.Services.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

using Moq;
using LNU_Test_Portal.Controllers;

namespace TestProject1
{
    [TestFixture]
    public class CourseTests
    {

        private readonly CourseService courseService;
        private readonly Mock<IRepository<Course>> courseRepo;

        public CourseTests()
        {
            courseRepo = new Mock<IRepository<Course>>();
            courseService = new CourseService(courseRepo.Object);
        }

         
        [Test]
        public void GetCourseByIdTestReturnCourse()
        {

            //Arrange
            var courses = new List<Course>() { new Course { id = 1 }, new Course { id = 2 }, new Course { id = 3 } };
            var FirstCourse = courses.First();
            var expected = FirstCourse;

            //Act
            courseRepo.Setup(x => x.SelectOneById(FirstCourse.id)).Returns(FirstCourse);      
            var ReturnedCourse = courseService.GetCourseById(FirstCourse.id);
            var actual = ReturnedCourse;
            
            //Assert
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void GetCourseByIdReturNullTest()
        {

            //Arrange
            var courses = new List<Course>() { new Course { id = 1 }, new Course { id = 2 }, new Course { id = 3 } };
            int courseId = 1000;
            var FirstCourse = new Course();

            //Act
            courseRepo.Setup(x => x.SelectOneById(courseId)).Returns(FirstCourse);
            var ReturnedCourse = courseService.GetCourseById(FirstCourse.id);
            var actual = ReturnedCourse;

            //Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void GetAllCoursesForStudentTest()
        {

            //Arrange
            ApplicationUser student = new ApplicationUser { Id = "5fkfjf", Email = "em@com" };
            var courses = new List<Course>() { new Course { id = 1, Students = new List<ApplicationUser>() {student } },
                new Course { id = 2,Students=new List<ApplicationUser>(){ student} } };
            var expected = courses.Count();

            //Act
            courseRepo.Setup(x => x.SelectAll(x=>x.Students.Contains(student))).Returns(courses);
            var ReturnedCourses = courseService.GetAllCoursesForStudent(student);
            var actual = ReturnedCourses.Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllCoursesForTeacherTest()
        {

            //Arrange
            ApplicationUser teacher = new ApplicationUser { Id = "kjdd598", Email = "em@com2" };
            ApplicationUser student = new ApplicationUser { Id = "kjdd45", Email = "em@com" };
            string techerId = teacher.Id;
            var courses = new List<Course>() { new Course { id = 1, Students = new List<ApplicationUser>() {student }, TeacherId=techerId },
                new Course { id = 2,Students=new List<ApplicationUser>(){ student}, TeacherId=techerId }, };
            var expected = courses.Count();
            

            //Act
            courseRepo.Setup(x => x.SelectAll(x => x.TeacherId==techerId)).Returns(courses);
            var ReturnedCourses = courseService.GetAllCoursesForTeacher(techerId);
            var actual = ReturnedCourses.Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}