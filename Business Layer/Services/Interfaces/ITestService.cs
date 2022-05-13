using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.Interfaces
{
    public interface ITestService
    {
        //IEnumerable<Test> GetAllTests();
        IEnumerable<Test> GetAllTestsForTeacher(string TeacherId);
        void AddNewTest(Test test);
        public Test GetTestById(int Id);
        void UpdateTest(Test test);
        void DeleteTest(Test test);
    }
}
