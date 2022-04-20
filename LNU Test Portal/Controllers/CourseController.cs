using LNU_Test_Portal.DAL.interfaces;
using LNU_Test_Portal.Models;
using LNU_Test_Portal.ViewModels;
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

namespace LNU_Test_Portal.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly IAllCourses _allCourses;
        private readonly IConfiguration configuration;
        private readonly CourseDbContext _courseDbContext;

        public CourseController(ILogger<CourseController> logger, IAllCourses iallCourses, IConfiguration config, CourseDbContext context)
        {
            _logger = logger;
            _allCourses = iallCourses;
            this.configuration = config;
            _courseDbContext = context;
            

        }
        

        public IActionResult Index()
        {


            /*CoursesListViewModel obj = new CoursesListViewModel();
            obj.AllCourses = _allCourses.Courses;*/

            //return View(obj);

            List<Course> courses = new List<Course>();
            courses = _courseDbContext.Course.ToList();
            //try
            //{
                
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
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
            _courseDbContext.Add(course);
            _courseDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(long Id)
        {
            try
            {
                if (Id <= 0)
                {
                    return NotFound();
                }
                Course course = _courseDbContext.Course.FirstOrDefault(x => x.id == Id);
                if (course == null)
                {
                    return NotFound();
                }
                return View(course);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("id,name,description")] Course course)
        {
            try
            {
                if (id != course.id)
                    return NotFound();

                if (ModelState.IsValid)
                {
                    _courseDbContext.Update(course);
                    _courseDbContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to create course.");
            }

            return View(course);
        }


        

        public IActionResult Delete(long Id)
        {
            try
            {
                if (Id <= 0)
                {
                    return NotFound();
                }
                Course course = _courseDbContext.Course.FirstOrDefault(x => x.id == Id);
                if (course == null)
                {
                    return NotFound();
                }
                return View(course);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long Id)
        {
            try
            {
                if (Id <= 0)
                {
                    return NotFound();
                }
                Course course = new Course { id = (int)Id };
                _courseDbContext.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _courseDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
