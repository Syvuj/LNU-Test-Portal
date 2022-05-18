using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.Interfaces
{
    public interface IQaAnResultsService
    {
        IEnumerable<QaAnResults> GetQnAn(string StudentId);
        void AddNewQnAn(QaAnResults qaAnResults);
        public QaAnResults GetQnAnById(int Id);
        void UpdateQnAn(QaAnResults qaAnResults);
        void DeleteQnAn(QaAnResults qaAnResults);
        IEnumerable<QaAnResults> GetAllQnAnForStudent(ApplicationUser Student);
    }
}
