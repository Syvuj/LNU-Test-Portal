using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions options) : base(options) { Database.EnsureCreated(); }
        public DbSet<Course> Course { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Question> Question { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Test>()
            .HasOne<Course>(s => s.Course)
            .WithMany(g => g.Tests)
            .HasForeignKey(s => s.CourseId);

           
            modelBuilder.Entity<Question>()
            .HasOne<Test>(s => s.Test)
            .WithMany(g => g.Questions)
            .HasForeignKey(s => s.TestId);


            modelBuilder.Entity<ApplicationUser>()
                .HasMany<Course>(s => s.Courses)
                .WithMany(c => c.Students);
        }
    }
}