using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.Interfaces
{
    public interface ITestResultsService
    {
        IEnumerable<TestResults> GetTRes(string StudentId);
        void AddNewTRes(TestResults TestResults);
        public TestResults GetTResById(int Id);
        void UpdateTRes(TestResults TestResults);
        void DeleteTRes(TestResults TestResults);
        IEnumerable<TestResults> GetAllTResForStudent(Test test);
    }
}
