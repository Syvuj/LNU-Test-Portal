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
    public class QaAnResultsService: IQaAnResults
    {
        private readonly IRepository<QaAnResults> repository;
        public QaAnResultsService(IRepository<QaAnResults> repository)
        {
            this.repository = repository;
        }

        public void AddNewQnAn(QaAnResults qaAnResults)
        {
            repository.Insert(qaAnResults);
        }

        public void DeleteQnAn(QaAnResults qaAnResults)
        {
            repository.Delete(qaAnResults);
        }

        public IEnumerable<QaAnResults> GetAllQnAnForStudent(ApplicationUser Student)
        {
            return repository.SelectAll(p => p.Student ==Student)
                 .Select(x => new QaAnResults
                 {
                     id = x.id,
                     Student = x.Student,
                     StudentId = x.StudentId,
                     QuestionAnswer = x.QuestionAnswer,
                     QuestionId = x.QuestionId,
                     StudentAnswScore = x.StudentAnswScore
                 }
                 );
        }

        public IEnumerable<QaAnResults> GetQnAn(string StudentId)
        {
            throw new NotImplementedException();
        }

        public QaAnResults GetQnAnById(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateQnAn(QaAnResults QaAnResults)
        {
            throw new NotImplementedException();
        }
    }
}
