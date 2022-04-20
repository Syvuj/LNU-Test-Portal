using LNU_Test_Portal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNU_Test_Portal.Data
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options):base(options)
        {

        }
        public DbSet<Course> Course { get; set; }
    }
}