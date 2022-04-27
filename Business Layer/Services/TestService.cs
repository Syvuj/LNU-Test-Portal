using Business_Layer.Services.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class TestService : ITestService,ICourseService
    {
        private readonly IRepository<Test> testRepository;
        private readonly IRepository<Course> courseRepository;
        public TestService(IRepository<Test> testRepository, IRepository<Course> courseRepository)
        {
            this.testRepository = testRepository;
            this.courseRepository = courseRepository;
    }

        public void AddNewCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public void AddNewTest(Test test)
        {
            testRepository.Insert(test);
        }

        public void DeleteCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public void DeleteTest(Test test)
        {
            testRepository.Delete(test);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Test> GetAllTests()
        {
            return testRepository.SelectAll()
                 .Select(x => new Test
                 {
                     id = x.id,
                     name = x.name,
                     description = x.description,
                     CourseId = courseRepository.SelectOneById(x.CourseId).id,
                     Course = courseRepository.SelectOneById(x.CourseId)
        }) ;
        
        }

        public IEnumerable<Test> GetAllTests(int CourseId)
        {
            return testRepository.SelectAll()
                .Select(x => new Test
                {
                    id = x.id,
                    name = x.name,
                    description = x.description,
                    CourseId = CourseId,
                    Course = courseRepository.SelectOneById(CourseId)
                });
        }

        public Course GetCourseById(int Id)
        {
            throw new NotImplementedException();
        }

        public Test GetTestById(int Id)
        {
            return testRepository.SelectOneById(Id);
        }

        public void UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public void UpdateTest(Test test)
        {
            testRepository.Update(test);
        }
    }
}
