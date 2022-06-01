
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
using Microsoft.AspNetCore.Identity;
using LNU_Test_Portal.ViewModels;

namespace LNU_Test_Portal.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        private readonly ILogger<TestController> logger;
        private readonly IConfiguration configuration;
        private readonly ITestService testService;
        private readonly ICourseService  courseService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IQaAnResultsService qaAnResultService;
        private readonly IQuestionService questionService;

        public TestController(ILogger<TestController> logger, IConfiguration configuration, ITestService testService, ICourseService courseService,
            SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IQaAnResultsService qaAnResultService,
            IQuestionService questionService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.testService = testService;
            this.courseService = courseService;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.qaAnResultService = qaAnResultService;
            this.questionService = questionService;
        }
        [Authorize]
        public IActionResult GetAllTests()
        {
            if (signInManager.IsSignedIn(User) && User.IsInRole("Teacher"))
            {
                var userId = userManager.GetUserId(User);
                var tests = testService.GetAllTestsForTeacher(userId).ToArray();
                TestViewModel[] testsView = new TestViewModel[tests.Count()];
                for (int i = 0; i < tests.Count(); i++)
                {
                    testsView[i] = new TestViewModel();
                    testsView[i].CourseId = tests[i].CourseId;
                    testsView[i].Course = courseService.GetCourseById(testsView[i].CourseId);
                    testsView[i].description = tests[i].description;
                    testsView[i].id = tests[i].id;
                    testsView[i].Questions = tests[i].Questions;
                    testsView[i].name = tests[i].name;
                }
                return View(testsView.ToList());
            }
                

            if (signInManager.IsSignedIn(User) && User.IsInRole("Student"))
            {
                var userId = userManager.GetUserId(User);
                ApplicationUser student = userManager.Users.FirstOrDefault(p => p.Id == userId);
                var tests2 = testService.GetAllTestsForStudent(student).ToArray();
                TestViewModel[] testsView = new TestViewModel[tests2.Count()];
               
                
                for (int i = 0; i < tests2.Count(); i++)
                {
                    bool isFirstAttemp = true;
                    int CountAttemps = qaAnResultService.GetAllQnAnForStudentByTestId(student.Id,
                        tests2[i].id).Select(p => p.TestId).Distinct().Count();
                    if (CountAttemps > 0)
                    {
                        isFirstAttemp = false;
                    }
                    testsView[i] = new TestViewModel();
                    testsView[i].CourseId = tests2[i].CourseId;
                    testsView[i].Course = courseService.GetCourseById(testsView[i].CourseId);
                    testsView[i].description = tests2[i].description;
                    testsView[i].id = tests2[i].id;
                    testsView[i].Questions = tests2[i].Questions;
                    testsView[i].name = tests2[i].name;
                    testsView[i].isFirstAttemp = isFirstAttemp;
                    testsView[i].TotalAvailablePoits = questionService.GetAllQuestions(testsView[i].id).Select(p => p.Scores).Sum();
                    testsView[i].SumByTest = qaAnResultService.GetAllQnAnForStudentByTestId(student.Id,testsView[i].id).Select(p => p.StudentAnswScore).Sum();
                }
                return View(testsView.ToList());
            }
            return View();
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            try
            {
                var test = new Test();
                ViewData["AviableCourses"] = courseService.GetAllCoursesForTeacher(userManager.GetUserId(User));
                return View(test);
            }
            catch
            {
                logger.LogError("Error when trying to create test in post method");
                return RedirectToAction(nameof(GetAllTests));
            }

        }

        [Authorize(Roles = "Teacher")]
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
                ViewData["AviableCourses"] = courseService.GetAllCoursesForTeacher(userManager.GetUserId(User));
                return View(test);
            }
            catch
            {
                logger.LogError("Error occured when trying to edit test in get method");
                return RedirectToAction(nameof(GetAllTests));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
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

        [Authorize(Roles = "Teacher")]
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