using LNU_Test_Portal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNU_Test_Portal.Data
{
    public class AddData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CourseDbContext(serviceProvider.GetRequiredService<DbContextOptions<CourseDbContext>>()))
            {
                if (context.Course.Any()) { return; }

                List<Course> courses = new List<Course>()
                {
                    new Course(){ name = "Bangladesh", description = "BDdg gdggd hhhdhd"},
                    new Course(){ name = "India", description = "INDddd gdggdgdg "},
                    new Course(){ name = "Canada", description = "CAN fdffdfdfd "}
                };

                context.Course.AddRange(courses);
                
                context.SaveChanges();
            }
        }
    }
}