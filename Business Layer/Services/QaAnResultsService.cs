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
    public class QaAnResultsService: IQaAnResultsService
    {
        private readonly IQaAnResultsRepository<QaAnResults> repository;
        public QaAnResultsService(IQaAnResultsRepository<QaAnResults> repository)
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
            throw new NotImplementedException();
        }

        //public IEnumerable<QaAnResults> GetAllQnAnForStudent(ApplicationUser Student)
        //{
        //    return repository.SelectAll()
        //         .Select(x => new QaAnResults
        //         {
        //             id = x.id,
        //             Student = x.Student,
        //             StudentId = x.StudentId,
        //             QuestionAnswer = x.QuestionAnswer,
        //             QuestionId = x.QuestionId,
        //             StudentAnswScore = x.StudentAnswScore,
        //             StudAnsw = x.StudAnsw

        //         }
        //         );
        //}

        public IEnumerable<QaAnResults> GetQnAn(string StudentId)
        {
            return repository.SelectAll(x => x.StudentId == StudentId).Select(p=>new QaAnResults
            {
                id = p.id,
                CorectAnswer = p.CorectAnswer,
                QuestionId = p.QuestionId,
                StudAnsw = p.StudAnsw,
                StudentAnswScore = p.StudentAnswScore,
                StudentId = StudentId
            });
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
