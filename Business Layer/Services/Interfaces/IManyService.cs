using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.Interfaces
{
    public interface IManyService
    {
        IEnumerable<ApplicationUserCourse> GetAllUserCourse();
        void AddNewUserCourse(ApplicationUserCourse applicationUserCourse);
        //void UpdateTest(ApplicationUserCourse applicationUserCourse);
        void DeleteUserCourse(ApplicationUserCourse applicationUserCourse);
    }
}
