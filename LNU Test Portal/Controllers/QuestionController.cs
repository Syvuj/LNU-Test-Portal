
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
using Microsoft.AspNetCore.Identity;
using LNU_Test_Portal.ViewModels;

namespace LNU_Test_Portal.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly ILogger<TestController> logger;
        private readonly IConfiguration configuration;
        private readonly ITestService testService;
        private readonly IQuestionService  questionService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IQaAnResultsService qaAnResultService;
        private readonly ITestResultsService testResultsService;


        public QuestionController(ILogger<TestController> logger, IConfiguration configuration, ITestService testService, IQuestionService questionService,
           SignInManager<ApplicationUser> signInManager, IQaAnResultsService qaAnResultService, ITestResultsService testResultsService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.testService = testService;
            this.questionService = questionService;
            this.signInManager = signInManager;
            this.qaAnResultService = qaAnResultService;
            this.testResultsService = testResultsService;
        }

        [Route("Question/GetAllQuestions/{TestId:int}")]
        public IActionResult GetAllQuestions(int TestId)
        {
            var questions = questionService.GetAllQuestions(TestId);
            TempData["TestIdData"] = TestId;
            TempData["CurrentTest"] = testService.GetTestById(TestId);
            return View(questions);
        }

        [Authorize(Roles = "Teacher")]
        [Route("Question/Create/{TestId:int}")]
        public IActionResult Create(int TestId)
        {
            try
            {
                var question = new Question();
                ViewData["CurrentTest"] = testService.GetTestById((int)TempData["TestIdData"]);
                return View(question);
            }
            catch
            {
                logger.LogError("Error when trying to create question in post method");
                return RedirectToAction(nameof(GetAllQuestions), new { TestId = TestId });
            }

        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Question/Create/{TestId:int}")]
        public IActionResult Create([Bind("Title,Scores,Key,Options")] Question question, int TestId)
        {
            try
            {
                
                question.Test = testService.GetTestById(TestId);
                question.TestId = TestId;
                questionService.AddNewQuestion(question);
            }
            catch
            {
                logger.LogError("Error when trying to create question in post method");
            }
            
            return RedirectToAction(nameof(GetAllQuestions),new { TestId = TestId }); 
        }



        [Route("Question/Edit/{TestId:int}/{id}")]
        [Authorize(Roles = "Teacher")]
        public IActionResult Edit(int Id, int TestId)
        {
            try
            {
                Question question = questionService.GetQuestionById(Id);
                ViewData["CurrentTest"] = testService.GetTestById(TestId);
                return View(question);
            }
            catch
            {
                logger.LogError("Error occured when trying to edit test in get method");
                return RedirectToAction(nameof(GetAllQuestions), new { TestId = TestId });
            }
        }

        [HttpPost]
        [Route("Question/Edit/{TestId:int}/{id}")]
        [Authorize(Roles = "Teacher")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("id,Title,Scores,Key,Options")] Question question, int TestId)
        {
            question.Test = (Test)ViewData["CurrentTest"];
            question.TestId = testService.GetTestById(TestId).id;
            try
            {
                if (ModelState.IsValid)
                {
                    questionService.UpdateQuestion(question);
                    return RedirectToAction(nameof(GetAllQuestions), new { TestId = TestId });
                }
            }
            catch
            {
                logger.LogError("Error occured when trying to edit test in post method");
                return RedirectToAction(nameof(GetAllQuestions), new { TestId = TestId });
            }
            return View(question);
        }





        [Route("Question/Delete/{TestId:int}/{id}")]
        [Authorize(Roles = "Teacher")]
        public IActionResult Delete(int Id, int TestId)
        {
            try
            {
                Question question = questionService.GetQuestionById(Id);
                ViewData["CurrentTest"] = testService.GetTestById(TestId);
                return View(question);
            }
            catch
            {
                logger.LogError("Error occured when trying to edit test in get method");
                return RedirectToAction(nameof(GetAllQuestions), new { TestId = TestId });
            }
        }

        [Authorize(Roles = "Teacher")]
        [Route("Question/Delete/{TestId:int}/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id,int TestId)
        {
            try
            {
                Question question = new Question { id = Id };
                questionService.DeleteQuestion(question);
                return RedirectToAction(nameof(GetAllQuestions), new { TestId = TestId });
            }
            catch
            {
                logger.LogError("Error occured when trying to delete test");
                return RedirectToAction(nameof(GetAllQuestions), new { TestId = TestId });
            }
        }



        [Authorize(Roles = "Student")]
        [Route("Question/StartTest/{TestId:int}")]
        public IActionResult StartTest(int TestId)
        {
            var questions = questionService.GetAllQuestions(TestId).ToArray();

            QaAnViewModel [] qaAnViewModel = new QaAnViewModel[questions.Count()];
            for(int i = 0; i < questions.Count(); i++)
            {
                qaAnViewModel[i] = new QaAnViewModel();
                
                qaAnViewModel[i].id = questions[i].id;
                qaAnViewModel[i].Key = questions[i].Key;
                qaAnViewModel[i].Options = questions[i].Options;
                qaAnViewModel[i].Scores = questions[i].Scores;
                qaAnViewModel[i].TestId = questions[i].TestId;
                qaAnViewModel[i].Test = questions[i].Test;
                qaAnViewModel[i].Title = questions[i].Title;
                


            }

            List<QaAnViewModel> qNvm = qaAnViewModel.ToList();
            TempData["TestIdData"] = TestId;
            TempData["CurrentTest"] = testService.GetTestById(TestId);

            return View(qNvm);
        }

        [Authorize(Roles = "Student")]
        [Route("Question/StartTest/{TestId:int}")]
        [HttpPost]
        public IActionResult StartTest(int TestId,List<QaAnViewModel> questions)
        {
            for (int i = 0; i < questions.Count(); i++)
            {
                QaAnResults qaAnResults = new QaAnResults();
                qaAnResults.QuestionId = questions[i].id;
                qaAnResults.StudentId = User.Identity.GetUserId();
                qaAnResults.StudAnsw = questions[i].NewStudentAnswer;
                qaAnResults.CorectAnswer = questions[i].Key;
                
                

                if (questions[i].NewStudentAnswer == questions[i].Key)
                {
                    qaAnResults.StudentAnswScore = questions[i].Scores;
                }
                else
                {
                    qaAnResults.StudentAnswScore = 0;
                }
                qaAnResultService.AddNewQnAn(qaAnResults);

            }

            return ReviewTest(TestId);
        }


        [Authorize(Roles = "Student")]
        [Route("Question/ReviewTest/{TestId:int}")]
        public IActionResult ReviewTest(int TestId)
        {
            var questions = questionService.GetAllQuestions(TestId).ToArray();

            QaAnViewModel[] qaAnViewModel = new QaAnViewModel[questions.Count()];
            for (int i = 0; i < questions.Count(); i++)
            {
                qaAnViewModel[i] = new QaAnViewModel();

                qaAnViewModel[i].id = questions[i].id;
                qaAnViewModel[i].Key = questions[i].Key;
                qaAnViewModel[i].Options = questions[i].Options;
                qaAnViewModel[i].Scores = questions[i].Scores;
                qaAnViewModel[i].TestId = questions[i].TestId;
                qaAnViewModel[i].Test = questions[i].Test;
                qaAnViewModel[i].Title = questions[i].Title;
                qaAnViewModel[i].NewStudentAnswer = qaAnResultService.GetQnAn(User.Identity.GetUserId()).Select(p=>p.StudAnsw).ToArray()[i];
                qaAnViewModel[i].StudentScorecByQues = qaAnResultService.GetQnAn(User.Identity.GetUserId()).Select(p => p.StudentAnswScore).ToArray()[i];


            }

            List<QaAnViewModel> qNvm = qaAnViewModel.ToList();
            TempData["TestIdData"] = TestId;
            TempData["CurrentTest"] = testService.GetTestById(TestId);

            return View(qNvm);
        }


    }
}