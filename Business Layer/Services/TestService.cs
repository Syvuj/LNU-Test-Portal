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
    public class TestService : ITestService
    {
        private readonly IRepository<Test> testRepository;
        private readonly IRepository<Course> courseRepository;
        public TestService(IRepository<Test> testRepository, IRepository<Course> courseRepository)
        {
            this.testRepository = testRepository;
            this.courseRepository = courseRepository;
        }
        public void AddNewTest(Test test)=> testRepository.Insert(test);
        public void DeleteTest(Test test)=> testRepository.Delete(test);

        public IEnumerable<Test> GetAllTestsForTeacher(string TeacherId)
        {
            return testRepository.SelectAll(p=>p.Course.TeacherId == TeacherId)
                 .Select(x => new Test
                 {
                     id = x.id,
                     name = x.name,
                     description = x.description,
                     CourseId = x.CourseId,
                     Course = courseRepository.SelectOneById(x.CourseId),
                     Questions = x.Questions
                     
                 }
                 ) ;
        }

        //public IEnumerable<Test> GetAllTests(int CourseId)
        //{
        //    return testRepository.SelectAll()
        //        .Select(x => new Test
        //        {
        //            id = x.id,
        //            name = x.name,
        //            description = x.description,
        //            CourseId = CourseId,
        //            Course = courseRepository.SelectOneById(CourseId)
        //        });
        //}

        public Test GetTestById(int Id)=> testRepository.SelectOneById(Id);
        public void UpdateTest(Test test)=> testRepository.Update(test);
    }
}
