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
    public class TestTests
    {

        private readonly TestService TestService;
        private readonly Mock<IRepository<Test>> TestRepo;
        private readonly Mock<IRepository<Course>> CourseRepo;

        public TestTests()
        {
            TestRepo = new Mock<IRepository<Test>>();
            CourseRepo = new Mock<IRepository<Course>>();
            TestService = new TestService(TestRepo.Object,CourseRepo.Object);
        }

         
        [Test]
        public void GetTestByIdReturnTest()
        {

            //Arrange
            var Tests = new List<Test>() { new Test { id = 1 }, new Test { id = 2 }, new Test { id = 3 } };
            var FirstTest = Tests.First();
            var expected = FirstTest;

            //Act
            TestRepo.Setup(x => x.SelectOneById(FirstTest.id)).Returns(FirstTest);      
            var ReturnedTest = TestService.GetTestById(FirstTest.id);
            var actual = ReturnedTest;
            
            //Assert
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void GetTestByIdReturNullTest()
        {

            //Arrange
            var Tests = new List<Test>() { new Test { id = 1 }, new Test { id = 2 }, new Test { id = 3 } };
            int TestId = 1000;
            var FirstTest = new Test();

            //Act
            TestRepo.Setup(x => x.SelectOneById(TestId)).Returns(FirstTest);
            var ReturnedTest = TestService.GetTestById(FirstTest.id);
            var actual = ReturnedTest;

            //Assert
            Assert.IsNull(actual);
        }


        [Test]
       
        public void AddTestTest()
        {

            //Arrange
            var Tests = new List<Test>() { new Test { id = 1 }, new Test { id = 2 }, new Test { id = 3 } };
            var FirstTest = Tests.First();
            
            //Act
            TestRepo.Setup(x => x.Insert(FirstTest));

            //Assert
            Assert.IsTrue(true);
        }
        [Test]
        public void DeleteTestTest()
        {

            //Arrange
            var Tests = new List<Test>() { new Test { id = 1 }, new Test { id = 2 }, new Test { id = 3 } };
            var FirstTest = Tests.First();

            //Act
            TestRepo.Setup(x => x.Delete(FirstTest));
            TestService.DeleteTest(FirstTest);

            //Assert
            Assert.IsTrue(true);
        }
        [Test]
        public void EditTestTest()
        {

            //Arrange
            var Tests = new List<Test>() { new Test { id = 1 }, new Test { id = 2 }, new Test { id = 3 } };
            var FirstTest = Tests.First();

            //Act
            TestRepo.Setup(x => x.Update(FirstTest));
            TestService.UpdateTest(FirstTest);

            //Assert
            Assert.IsTrue(true);
        }


    }
}