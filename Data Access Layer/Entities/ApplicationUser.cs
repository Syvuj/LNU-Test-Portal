using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Data_Access_Layer.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public string City { get; set; }
        public  List<Course> Courses { get; set; }
        public List<ApplicationUserCourse> ApplicationUserCourses { get; set; }

        
    }
}
