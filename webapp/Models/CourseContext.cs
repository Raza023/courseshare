using System;
using Microsoft.EntityFrameworkCore;     //add this for DBContext
using webapp.Models.Interfaces;
using webapp.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using webapp.Models;
using Microsoft.AspNetCore.Cors;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Schema;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Web;

namespace webapp.Models
{
    public class CourseContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Video> Videos { get; set; }

        // private readonly ICourse courseRepo;
        // private readonly ISeller sellerRepo;
        // public CourseContext(ICourse cr, ISeller isr)
        // {
        //     courseRepo = cr;
        //     sellerRepo = isr;
        // }
        
        // The following configures EF to create a SqlServer database file in the special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=courseshare;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");

        /*
        public override int SaveChanges()
        {
            var tracker = ChangeTracker;
            foreach (var entry in tracker.Entries())
            {
                System.Console.WriteLine($"{entry.Entity} has state {entry.State}");
            }
            return base.SaveChanges();
        }
        */

        public override int SaveChanges()
        {
            var tracker = ChangeTracker;
            foreach (var entry in tracker.Entries())
            {
                //Console.WriteLine(entry.Entity.ToString());
                if (entry.Entity.ToString() == "webapp.Models.Users")
                {
                    //System.Console.WriteLine($"{entry.Entity} has state {entry.State}");
                    var referenceEntity = entry.Entity as Users;
                    switch (entry.State)
                    {
                    case EntityState.Added:
                        referenceEntity.CreatedDate = DateTime.Now;
                        referenceEntity.CreatedByUserId = "1";//hard coded user id
                    break;
                    case EntityState.Deleted:
                    case EntityState.Modified:
                        referenceEntity.LastModifiedDate = DateTime.Now;
                        referenceEntity.LastModifiedUserId = "1";//hard coded user id
                    break;
                    default:
                    break;
                    }
                }
                else if (entry.Entity.ToString() == "webapp.Models.Video")
                {
                    // System.Console.WriteLine($"{entry.Entity} has state {entry.State}");
                    var referenceEntity = entry.Entity as Video;
                    switch (entry.State)
                    {
                    case EntityState.Added:
                        referenceEntity.CreatedDate = DateTime.Now;
                        referenceEntity.CreatedByUserId = sellerRepo.getSellerId("hassan").ToString();
                    break;
                    case EntityState.Deleted:
                    case EntityState.Modified:
                        referenceEntity.LastModifiedDate = DateTime.Now;
                        referenceEntity.LastModifiedUserId = sellerRepo.getSellerId("hassan").ToString();
                    break;
                    default:
                    break;
                    }
                }
                else if (entry.Entity.ToString() == "webapp.Models.Seller")
                {
                    // System.Console.WriteLine($"{entry.Entity} has state {entry.State}");
                    var referenceEntity = entry.Entity as Seller;
                    switch (entry.State)
                    {
                    case EntityState.Added:
                        referenceEntity.CreatedDate = DateTime.Now;
                        referenceEntity.CreatedByUserId = "1";//hard coded user id
                    break;
                    case EntityState.Deleted:
                    case EntityState.Modified:
                        referenceEntity.LastModifiedDate = DateTime.Now;
                        referenceEntity.LastModifiedUserId = "1";//hard coded user id
                    break;
                    default:
                    break;
                    }
                }
                else if (entry.Entity.ToString() == "webapp.Models.Course")
                {
                    // System.Console.WriteLine($"{entry.Entity} has state {entry.State}");
                    var referenceEntity = entry.Entity as Course;
                    SellerRepository sellerRepo = new SellerRepository();
                    switch (entry.State)
                    {
                    case EntityState.Added:
                        referenceEntity.CreatedDate = DateTime.Now;
                        referenceEntity.CreatedByUserId = sellerRepo.getSellerId("hassan").ToString();//hard coded user id
                    break;
                    case EntityState.Deleted:
                    case EntityState.Modified:
                        referenceEntity.LastModifiedDate = DateTime.Now;
                        referenceEntity.LastModifiedUserId = sellerRepo.getSellerId("hassan").ToString();//hard coded user id
                    break;
                    default:
                    break;
                    }
                }
                else if (entry.Entity.ToString() == "webapp.Models.Category")
                {
                    // System.Console.WriteLine($"{entry.Entity} has state {entry.State}");
                    var referenceEntity = entry.Entity as Category;
                    switch (entry.State)
                    {
                    case EntityState.Added:
                        referenceEntity.CreatedDate = DateTime.Now;
                        referenceEntity.CreatedByUserId = "1";//hard coded user id
                    break;
                    case EntityState.Deleted:
                    case EntityState.Modified:
                        referenceEntity.LastModifiedDate = DateTime.Now;
                        referenceEntity.LastModifiedUserId = "1";//hard coded user id
                    break;
                    default:
                    break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}