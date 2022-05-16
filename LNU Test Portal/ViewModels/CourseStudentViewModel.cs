using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_Access_Layer.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace LNU_Test_Portal.ViewModels
{
    public class CourseStudentViewModel:BaseEntity
    {
        //public int Id { get; set; }//course
        public string name { get; set; }//course
        public string description { get; set; }//course
        public List<CheckBoxItem> AvailableStudents { get; set; }
    }
}