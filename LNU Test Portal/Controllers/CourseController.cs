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


        public CourseController(ILogger<CourseController> logger, IConfiguration configuration, ICourseService courseService, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.courseService = courseService;
            this.signInManager = signInManager;
            this.userManager = userManager;
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
                    string id = item.Title;//not needed
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
        public IActionResult Edit(CourseStudentViewModel CSVM, Course course)
        {
            if (ModelState.IsValid)
            {
                //Course course = courseService.GetCourseById(Id);

                course.description = CSVM.description;
                course.name = CSVM.name;
                course.Students = new List<ApplicationUser>();
                List<ApplicationUser> stc = new List<ApplicationUser>();
                foreach (var item in CSVM.AvailableStudents)
                {
                    if (item.IsCheked)
                    {
                        ApplicationUser us = userManager.FindByIdAsync(item.Id).Result;
                        stc.Add(us);

                    }
                }

                course.Students = stc;

                var pty = course.Students.Select(p=>p.Email).ToList();
                //int count = course.Students.Count();

                


                // courseService.UpdateCourse(course);

                int courseId = course.id;
                //course.Students.Clear();
                //course.Students = new List<ApplicationUser>();
                //foreach (var item in CSVM.AvailableStudents)
                //{
                //    if (item.IsCheked)
                //    {
                //        ApplicationUser us = userManager.FindByIdAsync(item.Id).Result;
                //        course.Students.Add(us);

                //    }
                //}

                courseService.UpdateCourse(course);
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



        //[Authorize(Roles = "Teacher")]
        //[Route("Course/AddStudents/{id:int}")]
        //public IActionResult AddStudents(int id)
        //{

          

        //    CourseStudentViewModel CSVM = new CourseStudentViewModel();
        //    var course = courseService.GetCourseById(id);
        //    var students = userManager.Users;

        //    var allStudents = students.Select(vm => new CheckBoxItem()
        //    {
        //        Id = vm.Id,
        //        Title = vm.UserName,
        //        IsCheked = vm.Courses.Any(x => x.id == course.id) ? true : false

        //    }) ;

        //    CSVM.AvailableStudents = allStudents;



        //    CourseStudentViewModel CSVM2 = new CourseStudentViewModel();

        //    //CourseStudentViewModel m1 = new CourseStudentViewModel();
        //    //m1.AvailableStudents = students.Select(p => new CheckBoxItem()
        //    //{
        //    //    Id = p.Id,
        //    //    Title = p.UserName,
        //    //    IsCheked = course.Students.Any(x => x.Id == m1.AvailableStudents.Select(p => p.Id).FirstOrDefault()) ? true : false

        //    //}) ;
        //    return View(CSVM2);
        //}

        //[Authorize(Roles = "Teacher")]
        //[HttpPost]
        //[Route("Course/AddStudents/{id:int}")]
        //public IActionResult AddStudents(int id, CourseStudentViewModel CSVM)
        //{

           
        //    Course course = courseService.GetCourseById(id);
        //    List<ApplicationUser> sts = new List<ApplicationUser>();

        //    foreach(var item in CSVM.AvailableStudents)
        //    {
        //        if (item.IsCheked == true)
        //        {
        //            ApplicationUser usEr = userManager.FindByIdAsync(item.Id).Result;
        //            sts.Add(usEr);
        //        }
        //    }
        //    course.Students = sts;
        //    courseService.UpdateCourse(course);

        //    //courseService.ChangeStudents(course,students);
        //    return RedirectToAction(nameof(GetAllCourses));
        //}

    }
}