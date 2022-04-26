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
    public class CourseService:ICourseService
    {
        private readonly IRepository<Course> courseRepository;
        public CourseService(IRepository<Course> courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public IEnumerable<Course> GetAllCourses()
        {
            return courseRepository.SelectAll()
                .Select(x=> new Course {id=x.id, description=x.description,name=x.name});
        }
        public void AddNewCourse(Course course)=> courseRepository.Insert(course);
        public Course GetCourseById(int Id)=> courseRepository.SelectOneById(Id);
        public void UpdateCourse(Course course)=> courseRepository.Update(course);
        public void DeleteCourse(Course course)=> courseRepository.Delete(course);
    }
}
