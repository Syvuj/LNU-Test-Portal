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

        public DbSet<QaAnResults> QaAnResults { get; set; }
       

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
            .HasMany(p => p.Courses)
            .WithMany(p => p.Students)
            .UsingEntity<ApplicationUserCourse>(
                j => j
                    .HasOne(pt => pt.Course)
                    .WithMany(t => t.ApplicationUserCourses)
                    .HasForeignKey(pt => pt.CourseId),
                j => j
                    .HasOne(pt => pt.Student)
                    .WithMany(p => p.ApplicationUserCourses)
                    .HasForeignKey(pt => pt.StudentId),
                j =>
                {
                    j.HasKey(t => new { t.CourseId, t.StudentId });
                });



            //modelBuilder.Entity<TestResults>().HasOne(p => p.Student)
            //    .WithMany(t => t.TestResults).HasForeignKey(q => q.StudentId);

            








        }
    }
}