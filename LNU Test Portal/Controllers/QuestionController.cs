
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
using Microsoft.AspNet.Identity;

namespace LNU_Test_Portal.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly ILogger<TestController> logger;
        private readonly IConfiguration configuration;
        private readonly ITestService testService;
        private readonly IQuestionService  questionService;

        public QuestionController(ILogger<TestController> logger, IConfiguration configuration, ITestService testService, IQuestionService questionService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.testService = testService;
            this.questionService = questionService;
        }

        public IActionResult GetAllQuestions(int TestId)
        {
            var questions = questionService.GetAllQuestions(TestId);
            return View(questions);
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            try
            {
                var question = new Question();
                return View(question);
            }
            catch
            {
                logger.LogError("Error when trying to create question in post method");
                return RedirectToAction(nameof(GetAllQuestions));
            }

        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("")] Question question)
        {
            try
            {
                question.Test = testService.GetTestById(question.TestId);
                questionService.AddNewQuestion(question);
            }
            catch
            {
                logger.LogError("Error when trying to create question in post method");
            }
            
            return RedirectToAction(nameof(GetAllQuestions)); 
        }

        //[Authorize(Roles = "Teacher")]
        //public IActionResult Edit(int Id)
        //{
        //    try
        //    {
        //        Test test = testService.GetTestById(Id);
        //        ViewData["AviableCourses"] = courseService.GetAllCourses(User.Identity.GetUserId());
        //        return View(test);
        //    }
        //    catch
        //    {
        //        logger.LogError("Error occured when trying to edit test in get method");
        //        return RedirectToAction(nameof(GetAllTests));
        //    }
        //}

        //[HttpPost]
        //[Authorize(Roles = "Teacher")]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(int id, [Bind("id,name,description,CourseId,Course")] Test test)
        //{
        //    test.Course = courseService.GetCourseById(test.CourseId);
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            testService.UpdateTest(test);
        //            return RedirectToAction(nameof(GetAllTests));
        //        }
        //    }
        //    catch
        //    {
        //        logger.LogError("Error occured when trying to edit test in post method");
        //        return RedirectToAction(nameof(GetAllTests));
        //    }
        //    return View(test);
        //}

        //[Authorize(Roles = "Teacher")]
        //public IActionResult Delete(int Id)
        //{
        //    try
        //    {
        //        Test test = testService.GetTestById(Id);
        //        return View(test);
        //    }
        //    catch 
        //    {
        //        logger.LogError("Error occured when trying to delete test");
        //        return RedirectToAction(nameof(GetAllTests));
        //    }
        //}

        //[Authorize(Roles = "Teacher")]
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int Id)
        //{
        //    try
        //    {
        //        Test test = new Test { id = Id };
        //        testService.DeleteTest(test);
        //        return RedirectToAction(nameof(GetAllTests));
        //    }
        //    catch 
        //    {
        //        logger.LogError("Error occured when trying to delete test");
        //        return RedirectToAction(nameof(GetAllTests));
        //    }
        //}
    }
}