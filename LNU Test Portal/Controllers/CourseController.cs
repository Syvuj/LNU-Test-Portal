
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
        private readonly ILogger<CourseController> _logger;
        private readonly IConfiguration configuration;
        private readonly ICourseService courseService;

        public CourseController(ILogger<CourseController> logger,IConfiguration config, ICourseService courseService)
        {
            _logger = logger;
            configuration = config;
            this.courseService = courseService;
        }
        

        public IActionResult GetAllCourses()
        {
            var courses = courseService.GetAllCourses();
            return View(courses);
        }

        [HttpGet]
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

        //[HttpGet]
        //public IActionResult Edit(int Id)
        //{
        //    try
        //    {
        //        Course course = courseService.GetCoursesById(Id).FirstOrDefault();
        //        return View(course);
        //    }
        //    catch (Exception)
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

        //public IActionResult Delete(long Id)
        //{
        //    try
        //    {
        //        Course course = _courseDbContext.Course.FirstOrDefault(x => x.id == Id);
        //        if (course == null)
        //        {
        //            return NotFound();
        //        }
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
        //        _courseDbContext.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        //        _courseDbContext.SaveChanges();
        //        return RedirectToAction(nameof(GetAllCourses));
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction(nameof(GetAllCourses));
        //    }
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}