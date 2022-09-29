using System;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Net.Mime;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models.Interfaces;
using webapp.Models;

namespace webapp.Models.Repositories
{
    public class SellerRepository: ISeller
    {
        public int insertData(Seller s)
        {
            CourseContext db = new CourseContext();
            db.Sellers.Add(s);
            int writtenEntriesCount = db.SaveChanges();
            if(writtenEntriesCount > 0)
            {
                // is saved
                return s.ID;
            }
            else
            {
                // is not saved
                return 0;
            }
        }

        

        public bool getData(Seller s)
        {
            CourseContext db = new CourseContext();
            List<Seller> li = db.Sellers.Where(p => p.Username==s.Username && p.Password == s.Password).ToList();
            if(li.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }        
        }

        public bool checkUsername(Seller s)
        {
            CourseContext db = new CourseContext();
            List<Seller> li = db.Sellers.Where(p => p.Username==s.Username && p.Email == s.Email).ToList();
            if(li.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int addCourse(Course c)
        {
            CourseContext db = new CourseContext();
            db.Courses.Add(c);
            int writtenEntriesCount = db.SaveChanges();
            if(writtenEntriesCount > 0)
            {
                // is saved
                return c.ID;
            }
            else
            {
                // is not saved
                return 0;
            }
        }
        
        public int addVideo(Video v)
        {
            CourseContext db = new CourseContext();
            db.Videos.Add(v);
            int writtenEntriesCount = db.SaveChanges();
            if(writtenEntriesCount > 0)
            {
                // is saved
                return v.ID;
            }
            else
            {
                // is not saved
                return 0;
            }
        }
        
        public int updateThumbnail(Course c)
        {
            CourseContext db = new CourseContext();
            // db.Courses.Add(c);
            var crs = db.Courses.First(p => p.courseThumbnail.StartsWith("auxiname"));
            crs.courseThumbnail = c.courseThumbnail;
            int writtenEntriesCount = db.SaveChanges();
            if(writtenEntriesCount > 0)
            {
                // is saved
                return crs.ID;
            }
            else
            {
                // is not saved
                return 0;
            }
        }

        public int updateVideoName(Video v)
        {
            CourseContext db = new CourseContext();
            // db.Courses.Add(c);
            var vid = db.Videos.First(p => p.videoName.StartsWith("auxiname"));
            vid.videoName = v.videoName;
            int writtenEntriesCount = db.SaveChanges();
            if(writtenEntriesCount > 0)
            {
                // is saved
                return vid.ID;
            }
            else
            {
                // is not saved
                return 0;
            }
        }

        public int getSellerId(string uname)
        {
            CourseContext db = new CourseContext();
            Seller c = new Seller();
            c = db.Sellers.First(p => p.Username == uname);
            return c.ID;
        }

        public bool ApproveSeller(int id)
        {
            CourseContext db = new CourseContext();
            Seller s = db.Sellers.First(p => p.ID == id);
            s.IsActive = true;
            int changedRows = db.SaveChanges();
            if(changedRows>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UnApproveSeller(int id)
        {
            CourseContext db = new CourseContext();
            Seller s = db.Sellers.First(p => p.ID == id);
            s.IsActive = false;
            int changedRows = db.SaveChanges();
            if(changedRows>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}