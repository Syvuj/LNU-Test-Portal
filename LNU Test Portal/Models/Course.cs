using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LNU_Test_Portal.Models
{
    public class Course
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        //public string TeacherId { get; set; }
        //public List<User> Students {get;set;}
        //public List<Test> Tests { get; set; }*/
        //public Course(string id, string CName, string CDescription, string TeacherId, List<User> Students, List<Test> Tests)
        //{
        //    this.id = id;
        //    this.CName = CName;
        //    this.CDescription = CDescription;
        //    this.TeacherId = TeacherId;
        //    this.Students = Students;
        //    this.Tests = Tests;
        //}
    }
}