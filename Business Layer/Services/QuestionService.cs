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
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Test> testRepository;
        private readonly IRepository<Question> questionRepository;

        public QuestionService(IRepository<Test> testRepository, IRepository<Question> questionRepository)
        {
            this.testRepository = testRepository;
            this.questionRepository = questionRepository;
        }

        public void AddNewQuestion(Question question)
        {
            questionRepository.Insert(question);
        }

        public void DeleteQuestion(Question question)
        {
            questionRepository.Delete(question);
        }

        public IEnumerable<Question> GetAllQuestions(int TestId)
        {
           return  questionRepository.SelectAll(p => p.TestId == TestId).Select(x => new Question
            {
                id = x.id,
                Scores = x.Scores,
                Title = x.Title,
                Key = x.Key,
                Options = x.Options,
                TestId = TestId,
                Test = testRepository.SelectOneById(TestId)

            });
        }

        public Question GetQuestionById(int Id)
        {
           return questionRepository.SelectOneById(Id);
        }

        public void UpdateQuestion(Question question)
        {
            questionRepository.Update(question);
        }
    }
}
