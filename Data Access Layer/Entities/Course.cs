using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Entities
{
    public class Course : BaseEntity
    {
        public string name { get; set; }
        public string description { get; set; }
        //public string TeacherId { get; set; }
        //public List<User> Students {get;set;}
        //public List<Test> Tests { get; set; }*/
    }
}