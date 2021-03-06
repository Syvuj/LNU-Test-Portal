using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCoursesForTeacher(string TeacherId);
        void AddNewCourse(Course course);
        public Course GetCourseById(int Id);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);

        void ChangeStudents(Course course, IEnumerable<ApplicationUser> students);
        IEnumerable<Course> GetAllCoursesForStudent(ApplicationUser Student);
    }
}
