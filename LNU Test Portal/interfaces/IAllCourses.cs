using LNU_Test_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNU_Test_Portal.DAL.interfaces
{
    public interface IAllCourses
    {
        IEnumerable<Course> Courses { get; }
        Course getObjectCourse(int courseId);
    }
}
