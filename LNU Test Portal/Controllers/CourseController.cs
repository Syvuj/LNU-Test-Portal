
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using LNU_Test_Portal.Data;
using Business_Layer.Services;
using Business_Layer.Services.Interfaces;
using Data_Access_Layer.Entities;

namespace LNU_Test_Portal.Controllers
{
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
            var courses = courseService.GetAllCourses();
            return View(courses);
        }

        public IActionResult Create()
        {
            var model = new Course();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("name,description")] Course course)
        {
            courseService.AddNewCourse(course);
            return RedirectToAction(nameof(GetAllCourses));
        }

        public IActionResult Edit(int Id)
        {
            try
            {
                Course course = courseService.GetCourseById(Id);
                return View(course);
            }
            catch
            {
                return RedirectToAction(nameof(GetAllCourses));
            }
        }

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
            catch (Exception)
            {
                return RedirectToAction(nameof(GetAllCourses));
            }
            return View(course);
        }

        public IActionResult Delete(int Id)
        {
            try
            {
                Course course = courseService.GetCourseById(Id);
                return View(course);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(GetAllCourses));
            }
        }

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
            catch (Exception)
            {
                return RedirectToAction(nameof(GetAllCourses));
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}