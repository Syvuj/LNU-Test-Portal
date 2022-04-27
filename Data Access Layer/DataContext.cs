using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Data_Access_Layer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { Database.EnsureCreated(); }
        public DbSet<Course> Course { get; set; }
        public DbSet<Test> Test { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
            .HasOne<Course>(s => s.Course)
            .WithMany(g => g.Tests)
            .HasForeignKey(s => s.CourseId);

        }
    }
}