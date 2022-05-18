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
    public class TestResultsService: ITestResultsService
    {
        private readonly IRepository<TestResults> repository;
        public TestResultsService(IRepository<TestResults> repository)
        {
            this.repository = repository;
        }

        public void AddNewTRes(TestResults TestResults)
        {
            repository.Insert(TestResults);
        }

        public void DeleteTRes(TestResults TestResults)
        {
            repository.Delete(TestResults);
        }

        public IEnumerable<TestResults> GetAllTResForStudent(Test test)
        {
            return repository.SelectAll(p => p.Test == test)
                 .Select(x => new TestResults
                 {
                     id = x.id,
                     Student = x.Student,
                     StudentId = x.StudentId,
                     Test = x.Test,
                     TestId = x.TestId,
                     TotalStScore = x.TotalStScore ,
                     SolvedQuestions = x.SolvedQuestions
                 }
                 );
        }

        public IEnumerable<TestResults> GetTRes(string StudentId)
        {
            throw new NotImplementedException();
        }

        public TestResults GetTResById(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTRes(TestResults TestResults)
        {
            throw new NotImplementedException();
        }
    }
}
