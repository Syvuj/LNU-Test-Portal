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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;


namespace LNU_Test_Portal.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> logger;
        private readonly IConfiguration configuration;
        private readonly ICourseService courseService;

        public CourseController(ILogger<CourseController> logger, IConfiguration configuration, ICourseService courseService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.courseService = courseService;
        }

        public IActionResult GetAllCourses()
        {
            var courses = courseService.GetAllCourses(User.Identity.GetUserId());
            logger.LogInformation("Show all courses");
            return View(courses);
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            var model = new Course();
            return View(model);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("name,description")] Course course)
        {
            course.TeacherId = User.Identity.GetUserId();
            courseService.AddNewCourse(course);
            return RedirectToAction(nameof(GetAllCourses));
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Edit(int Id)
        {
            try
            {
                Course course = courseService.GetCourseById(Id);
                return View(course);
            }
            catch
            {
                logger.LogError("Error occured when trying to edit coure");
                return RedirectToAction(nameof(GetAllCourses));

            }
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("id,name,description")] Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    courseService.UpdateCourse(course);
                    return RedirectToAction(nameof(GetAllCourses));
                }
            }
            catch
            {
                logger.LogError("Error occured when trying to edit coure");
                return RedirectToAction(nameof(GetAllCourses));
            }
            return View(course);
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Delete(int Id)
        {
            try
            {
                Course course = courseService.GetCourseById(Id);
                return View(course);
            }
            catch
            {
                logger.LogError("Error occured when trying to delete coure");
                return RedirectToAction(nameof(GetAllCourses));
            }
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id)
        {
            try
            {
                Course course = new Course { id = Id };
                courseService.DeleteCourse(course);
                return RedirectToAction(nameof(GetAllCourses));
            }
            catch
            {
                logger.LogError("Error occured when trying to delete coure");
                return RedirectToAction(nameof(GetAllCourses));
            }
        }

    }
}