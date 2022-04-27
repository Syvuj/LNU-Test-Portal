
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Business_Layer.Services;
using Business_Layer.Services.Interfaces;
using Data_Access_Layer.Entities;
using System.Dynamic;

namespace LNU_Test_Portal.Controllers
{
    public class TestController : Controller
    {
        private readonly ILogger<CourseController> logger;
        private readonly IConfiguration configuration;
        private readonly ITestService testService;
        private readonly ICourseService  courseService;

        public TestController(ILogger<CourseController> logger, IConfiguration configuration, ITestService testService, ICourseService courseService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.testService = testService;
            this.courseService = courseService;
        }
        
        public IActionResult GetAllTests()
        {
            var tests = testService.GetAllTests();
            return View(tests);
        }

        public IActionResult Create()
        {

            var test = new Test();
            // test.CourseId = CourseID;
            //test.Course = courseService.GetCourseById(CourseID);
            ViewData["AviableCourses"] = courseService.GetAllCourses();
            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("name,description,CourseId,Course")] Test test)
        {
            testService.AddNewTest(test);
            //Console.WriteLine("///////////" + test.name + test.description + test.CourseId + test.Course.name);
            return RedirectToAction(nameof(GetAllTests));
            
        }

        //public IActionResult Edit(int Id)
        //{
        //    try
        //    {
        //        Course course = courseService.GetCourseById(Id);
        //        return View(course);
        //    }
        //    catch
        //    {
        //        return RedirectToAction(nameof(GetAllCourses));
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(int id, [Bind("id,name,description")] Course course)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            courseService.UpdateCourse(course);
        //            return RedirectToAction(nameof(GetAllCourses));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction(nameof(GetAllCourses));
        //    }
        //    return View(course);
        //}

        //public IActionResult Delete(int Id)
        //{
        //    try
        //    {
        //        Course course = courseService.GetCourseById(Id);
        //        return View(course);
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction(nameof(GetAllCourses));
        //    }
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int Id)
        //{
        //    try
        //    {
        //        Course course = new Course { id = Id };
        //        courseService.DeleteCourse(course);
        //        return RedirectToAction(nameof(GetAllCourses));
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction(nameof(GetAllCourses));
        //    }
        //}

    }
}