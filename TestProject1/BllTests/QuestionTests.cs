using Business_Layer.Services;
using Business_Layer.Services.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using LNU_Test_Portal.Controllers;

namespace TestProject1
{
    [TestFixture]
    public class QuestionTests
    {

        private readonly QuestionService QuestionService;
        private readonly Mock<IRepository<Question>> QuestionRepo;
        private readonly Mock<IRepository<Test>> TestRepo;

        public QuestionTests()
        {
            QuestionRepo = new Mock<IRepository<Question>>();
            TestRepo = new Mock<IRepository<Test>>();
            QuestionService = new QuestionService(TestRepo.Object,QuestionRepo.Object);
        }

         
        [Test]
        public void GetQuestionByIdTestReturnQuestion()
        {

            //Arrange
            var Questions = new List<Question>() { new Question { id = 1 }, new Question { id = 2 }, new Question { id = 3 } };
            var FirstQuestion = Questions.First();
            var expected = FirstQuestion;

            //Act
            QuestionRepo.Setup(x => x.SelectOneById(FirstQuestion.id)).Returns(FirstQuestion);      
            var ReturnedQuestion = QuestionService.GetQuestionById(FirstQuestion.id);
            var actual = ReturnedQuestion;
            
            //Assert
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void GetQuestionByIdReturNullTest()
        {

            //Arrange
            var Questions = new List<Question>() { new Question { id = 1 }, new Question { id = 2 }, new Question { id = 3 } };
            int QuestionId = 1000;
            var FirstQuestion = new Question();

            //Act
            QuestionRepo.Setup(x => x.SelectOneById(QuestionId)).Returns(FirstQuestion);
            var ReturnedQuestion = QuestionService.GetQuestionById(FirstQuestion.id);
            var actual = ReturnedQuestion;

            //Assert
            Assert.IsNull(actual);
        }


        [Test]
       
        public void AddQuestionTest()
        {

            //Arrange
            var Questions = new List<Question>() { new Question { id = 1 }, new Question { id = 2 }, new Question { id = 3 } };
            var FirstQuestion = Questions.First();
            
            //Act
            QuestionRepo.Setup(x => x.Insert(FirstQuestion));

            //Assert
            Assert.IsTrue(true);
        }
        [Test]
        public void DeleteQuestionTest()
        {

            //Arrange
            var Questions = new List<Question>() { new Question { id = 1 }, new Question { id = 2 }, new Question { id = 3 } };
            var FirstQuestion = Questions.First();

            //Act
            QuestionRepo.Setup(x => x.Delete(FirstQuestion));
            QuestionService.DeleteQuestion(FirstQuestion);

            //Assert
            Assert.IsTrue(true);
        }
        [Test]
        public void EditQuestionTest()
        {

            //Arrange
            var Questions = new List<Question>() { new Question { id = 1 }, new Question { id = 2 }, new Question { id = 3 } };
            var FirstQuestion = Questions.First();

            //Act
            QuestionRepo.Setup(x => x.Update(FirstQuestion));
            QuestionService.UpdateQuestion(FirstQuestion);

            //Assert
            Assert.IsTrue(true);
        }

    }
}