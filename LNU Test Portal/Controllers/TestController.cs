
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
        private readonly ILogger<TestController> logger;
        private readonly IConfiguration configuration;
        private readonly ITestService testService;
        private readonly ICourseService  courseService;

        public TestController(ILogger<TestController> logger, IConfiguration configuration, ITestService testService, ICourseService courseService)
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
            ViewData["AviableCourses"] = courseService.GetAllCourses();
            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("name,description,CourseId,Course")] Test test)
        {
            test.Course = courseService.GetCourseById(test.CourseId);
            testService.AddNewTest(test);
            return RedirectToAction(nameof(GetAllTests)); 
        }

        public IActionResult Edit(int Id)
        {
            try
            {
                Test test = testService.GetTestById(Id);
                ViewData["AviableCourses"] = courseService.GetAllCourses();
                return View(test);
            }
            catch
            {
                return RedirectToAction(nameof(GetAllTests));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("id,name,description,CourseId,Course")] Test test)
        {
            test.Course = courseService.GetCourseById(test.CourseId);
            try
            {
                if (ModelState.IsValid)
                {
                    testService.UpdateTest(test);
                    return RedirectToAction(nameof(GetAllTests));
                }
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(GetAllTests));
            }
            return View(test);
        }

        public IActionResult Delete(int Id)
        {
            try
            {
                Test test = testService.GetTestById(Id);
                return View(test);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(GetAllTests));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id)
        {
            try
            {
                Test test = new Test { id = Id };
                testService.DeleteTest(test);
                return RedirectToAction(nameof(GetAllTests));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(GetAllTests));
            }
        }
    }
}