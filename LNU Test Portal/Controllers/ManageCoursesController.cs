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

namespace LNU_Test_Portal.Controllers
{
    public class ManageCoursesController : Controller
    {
        private readonly ILogger<ManageCoursesController> _logger;
        private readonly IAllCourses _allCourses;

        public ManageCoursesController(ILogger<ManageCoursesController> logger, IAllCourses iallCourses)
        {
            _logger = logger;
            _allCourses = iallCourses;

        }

        public IActionResult Index()
        {
            CoursesListViewModel obj = new CoursesListViewModel();
            obj.AllCourses = _allCourses.Courses;
            return View(obj);
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
