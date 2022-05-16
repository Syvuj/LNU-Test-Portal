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
    public class ManyService: IManyService
    {
        private readonly IManyRepository<ApplicationUserCourse> manyRepository;
        public ManyService(IManyRepository<ApplicationUserCourse> manyRepository)
        {
            this.manyRepository = manyRepository;
        }

        public void AddNewUserCourse(ApplicationUserCourse applicationUserCourse)
        {
            manyRepository.Insert(applicationUserCourse);
        }

        public void DeleteUserCourse(ApplicationUserCourse applicationUserCourse)
        {
            manyRepository.Delete(applicationUserCourse);
        }

        public IEnumerable<ApplicationUserCourse> GetAllUserCourse()
        {
           return  manyRepository.SelectAll();
        }
    }
}
