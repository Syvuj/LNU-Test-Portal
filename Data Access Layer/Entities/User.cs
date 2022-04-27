using System.Runtime.InteropServices;
using System;

namespace Data_Access_Layer.Entities
{
    public class User
    {
        public string id { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsStudent { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string LogInUserName { get; set; }
        public string LogInPwd { get; set; }
    }
}