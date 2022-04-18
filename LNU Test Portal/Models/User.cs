using System.Runtime.InteropServices;
using System;

namespace LNU_Test_Portal.Models
{
    public class User
    {
        public string UserId { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsStudent { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string LogInUserName { get; set; }
        public string LogInPwd { get; set; }
        public User() { }
        public User(string UserId, bool IsTeacher, bool IsStudent, string Name, string SurName, string LogInUserName, string LogInPwd)
        {
            this.UserId = UserId;
            this.IsTeacher = IsTeacher;
            this.IsStudent = IsStudent;
            this.Name = Name;
            this.SurName = SurName;
            this.LogInUserName = LogInUserName;
            this.LogInPwd = LogInPwd;
        }
    }
}