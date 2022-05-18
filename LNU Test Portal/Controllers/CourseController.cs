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
//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using LNU_Test_Portal.ViewModels;
//using Microsoft.AspNetCore.Mvc;

namespace LNU_Test_Portal.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> logger;
        private readonly IConfiguration configuration;
        private readonly ICourseService courseService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IManyService manyService;


        public CourseController(ILogger<CourseController> logger, IConfiguration configuration, ICourseService courseService, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, IManyService manyService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.courseService = courseService;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.manyService = manyService;
        }

        [Authorize]
        public IActionResult GetAllCourses()
        {
            var userId = userManager.GetUserId(User);
            var courses = courseService.GetAllCoursesForTeacher(userId);
            if (signInManager.IsSignedIn(User) && User.IsInRole("Student"))
            {
                ApplicationUser student = userManager.Users.FirstOrDefault(p => p.Id == userId);
                courses = courseService.GetAllCoursesForStudent(student);
            }


            logger.LogInformation("Show all courses");
            
            return View(courses);
        }
        
      


        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            var model = new Course();
            var std = userManager.Users;
            CourseStudentViewModel m1 = new CourseStudentViewModel();
            m1.AvailableStudents = std.Select(vm => new CheckBoxItem()
            {
                Id = vm.Id,
                Title = vm.UserName,
                IsCheked = false
            }).ToList();
            return View(m1);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseStudentViewModel CSVM,  Course course)
        {
            course.description = CSVM.description;
            course.name = CSVM.name;

            course.Students = new List<ApplicationUser>();
            List<ApplicationUser> students = new List<ApplicationUser>();
            foreach (var item in CSVM.AvailableStudents)
            {
                if (item.IsCheked)
                {
                    ApplicationUser us = userManager.FindByIdAsync(item.Id).Result;
                    us.Courses = new List<Course>();
                    us.Courses.Add(course);
                    students.Add(us);
                   
                }
            }
            course.Students = students;
            

            course.TeacherId =  userManager.GetUserId(User);
            courseService.AddNewCourse(course);
            return RedirectToAction(nameof(GetAllCourses));
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Edit(int Id)
        {  

            try
            {
                Course course = courseService.GetCourseById(Id);
                CourseStudentViewModel CSVM = new CourseStudentViewModel();

                var std = userManager.Users;
               
                var allstudents = std.Select(vm => new CheckBoxItem()
                {
                    Id = vm.Id,
                    Title = vm.UserName,
                    IsCheked = vm.Courses.Any(x=>x.id==course.id) ?true:false
                }).ToList();

                CSVM.description = course.description;
                CSVM.name = course.name;
                CSVM.id = course.id;
                CSVM.AvailableStudents = allstudents;

                return View(CSVM);
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
        public IActionResult Edit(CourseStudentViewModel CSVM, Course course, ApplicationUserCourse auC)
        {
            if (ModelState.IsValid)
            {
                List<ApplicationUserCourse> stc = new List<ApplicationUserCourse>();

                course.description = CSVM.description;
                course.name = CSVM.name;
                course.TeacherId = userManager.GetUserId(User);
                courseService.UpdateCourse(course);

                int courseid = course.id;

                foreach (var item in CSVM.AvailableStudents)
                {
                    if (item.IsCheked)
                    {
                        stc.Add(new ApplicationUserCourse { CourseId = courseid, StudentId = item.Id});

                    }
                }

                var databasetable = manyService.GetAllUserCourse().Where(a => a.CourseId == courseid).ToList();
                var resultlist = databasetable.Except(stc).ToList();

                foreach(var item in resultlist)
                {
                    manyService.DeleteUserCourse(item);
                }

                var getstudentid = manyService.GetAllUserCourse().Where(a => a.CourseId == courseid).ToList();

               foreach(var item in stc)
                {
                    if (!getstudentid.Contains(item))
                    {
                        manyService.AddNewUserCourse(item);
                    }
                }

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