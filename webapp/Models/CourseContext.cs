using System;
using Microsoft.EntityFrameworkCore;     //add this for DBContext

namespace webapp.Models
{
    public class CourseContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Video> Videos { get; set; }
        
        // The following configures EF to create a SqlServer database file in the special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=courseshare;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
    }
}