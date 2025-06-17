using managment_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using YamlDotNet.Core;
using Mark = managment_api.Models.Mark;

namespace SchoolManagementApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // to read from assembly 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        // class maping to database 

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

    }
}
