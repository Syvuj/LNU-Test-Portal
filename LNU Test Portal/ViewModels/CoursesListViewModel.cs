using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using LNU_Test_Portal.Models;

namespace LNU_Test_Portal.ViewModels
{
    public class CoursesListViewModel
    {
       
      public IEnumerable<Course> AllCourses { get; set; }
    }
}