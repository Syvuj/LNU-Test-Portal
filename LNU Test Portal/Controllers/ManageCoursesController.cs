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
    public class ManageCoursesController : Controller
    {
        private readonly ILogger<ManageCoursesController> _logger;
        private readonly IAllCourses _allCourses;
        private readonly IConfiguration configuration;
        private readonly CourseDbContext _courseDbContext;

        public ManageCoursesController(ILogger<ManageCoursesController> logger, IAllCourses iallCourses, IConfiguration config, CourseDbContext context)
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

        public IActionResult CreateCourse()
        {
            return View();
        }
        public IActionResult EditCourse()
        {
            return View();
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
