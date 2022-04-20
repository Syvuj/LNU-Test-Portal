using LNU_Test_Portal.DAL.interfaces;
using LNU_Test_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNU_Test_Portal.DAL.mocks
{
    class MockCourse : IAllCourses
    {
        public IEnumerable<Course> Courses
        {
            get
            {
                return new List<Course>
                {
                    new Course {name="Python", description ="Python — інтерпретована об'єктно-орієнтована мова програмування високого рівня зі строгою динамічною типізацією. Розроблена в 1990 році Гвідо ван Россумом."},
                    new Course { name="Pascal", description ="Pascal — алгоритмічна мова програмування універсального призначення. Існують діалекти мови з підтримкою об'єктно-орієнтованого програмування. В 1990 році було затверджено стандарт ISO 7185:1990, «Pascal», та ISO 10206:1990 «Extended Pascal»"},
                    new Course {name="C++", description ="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt utlabore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut."},
                    new Course {name="C#", description ="C# — об'єктно-орієнтована мова програмування з безпечною системою типізації для платформи .NET. Розроблена Андерсом Гейлсбергом, Скотом Вілтамутом та Пітером Гольде під егідою Microsoft Research. Синтаксис C# близький до С++ і Java."}

                };
            }
         
        
        
        }

        public Course getObjectCourse(int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
