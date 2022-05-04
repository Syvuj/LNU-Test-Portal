
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
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            try
            {
                var test = new Test();
                ViewData["AviableCourses"] = courseService.GetAllCourses();
                return View(test);
            }
            catch
            {
                logger.LogError("Error when trying to create test in post method");
                return RedirectToAction(nameof(GetAllTests));
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("name,description,CourseId,Course")] Test test)
        {
            try
            {
                test.Course = courseService.GetCourseById(test.CourseId);
                testService.AddNewTest(test);
            }
            catch
            {
                logger.LogError("Error when trying to create test in post method");
            }
            
            return RedirectToAction(nameof(GetAllTests)); 
        }

        [Authorize(Roles = "Teacher")]
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
                logger.LogError("Error occured when trying to edit test in get method");
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
            catch
            {
                logger.LogError("Error occured when trying to edit test in post method");
                return RedirectToAction(nameof(GetAllTests));
            }
            return View(test);
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Delete(int Id)
        {
            try
            {
                Test test = testService.GetTestById(Id);
                return View(test);
            }
            catch 
            {
                logger.LogError("Error occured when trying to delete test");
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
            catch 
            {
                logger.LogError("Error occured when trying to delete test");
                return RedirectToAction(nameof(GetAllTests));
            }
        }
    }
}