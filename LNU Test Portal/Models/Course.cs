using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

namespace LNU_Test_Portal.Models
{
    public class Course
    {
        public string CourseId { get; set; }
        public string CName { get; set; }
        public string CDescription { get; set; }
        public string TeacherId { get; set; }
        public List<User> Students {get;set;}
        public List<Test> Tests { get; set; }
        public Course(string CourseId, string CName, string CDescription, string TeacherId, List<User> Students, List<Test> Tests)
        {
            this.CourseId = CourseId;
            this.CName = CName;
            this.CDescription = CDescription;
            this.TeacherId = TeacherId;
            this.Students = Students;
            this.Tests = Tests;
        }
    }
}