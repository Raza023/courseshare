using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models.Interfaces;


namespace webapp.Models.Repositories
{
    public class CourseRepository: ICourse
    {
        public List<Course> getDevCourses()
        {
            CourseContext db = new CourseContext();
            List<Course> li = db.Courses.Where(p => p.ID > 0).ToList();
            return li;
        }

        public List<Course> getSellerCourses(int sid)
        {
            CourseContext db = new CourseContext();
            List<Course> li = db.Courses.Where(p => p.SellerId == sid).ToList();
            return li;
        }
        
        public List<Course> getDevelopmentCourses()
        {
            CourseContext db = new CourseContext();
            List<Course> li = db.Courses.Where(p => p.category == "Development" && p.IsActive == true).ToList();
            return li;
        }
        
        public List<Course> getPhotographyCourses()
        {
            CourseContext db = new CourseContext();
            List<Course> li = db.Courses.Where(p => p.category == "Photography & Video"  && p.IsActive == true).ToList();
            return li;
        }
        public List<Course> getTeachingCourses()
        {
            CourseContext db = new CourseContext();
            List<Course> li = db.Courses.Where(p => p.category == "Teaching & Academic"  && p.IsActive == true).ToList();
            return li;
        }
        public List<Course> getDesignCourses()
        {
            CourseContext db = new CourseContext();
            List<Course> li = db.Courses.Where(p => p.category == "Design"  && p.IsActive == true).ToList();
            return li;
        }
        public List<Course> getHealthCourses()
        {
            CourseContext db = new CourseContext();
            List<Course> li = db.Courses.Where(p => p.category == "Health & Fitness"  && p.IsActive == true).ToList();
            return li;
        }
        public List<Course> getBusinessCourses()
        {
            CourseContext db = new CourseContext();
            List<Course> li = db.Courses.Where(p => p.category == "Business"  && p.IsActive == true).ToList();
            return li;
        }

        public Course getCourse(int id)
        {
            CourseContext db = new CourseContext();
            Course c = db.Courses.First(p => p.ID == id);

            return c;
        }

        public List<Video> getCourseVideos(int id)
        {
            CourseContext db = new CourseContext();
            List<Video> li = db.Videos.Where(p => p.CourseId == id).ToList();
            return li;
        }

        public Video getCourseVideo(int id)
        {
            CourseContext db = new CourseContext();
            Video v = db.Videos.First(p => p.ID == id);
            return v;
        }

        public bool deleteCourse(int id)
        {
            CourseContext db = new CourseContext();
            Course c = db.Courses.First(p => p.ID == id);
            db.Remove(c);
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

        public string getCourseThumbnailName(int id)
        {
            CourseContext db = new CourseContext();
            Course c = db.Courses.First(p => p.ID == id);
            return c.courseThumbnail;
        }

        
        public bool updateCourse(int id, Course c)
        {
            CourseContext db = new CourseContext();
            Course nc = db.Courses.First(p => p.ID == id);
            nc.courseName = c.courseName;
            nc.courseDescription = c.courseDescription; 
            nc.courseThumbnail = c.courseThumbnail;
            nc.category = c.category;
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

        
        public bool updateVideo(int id, Video v)
        {
            CourseContext db = new CourseContext();
            Video nv = db.Videos.First(p => p.ID == id);
            nv.videoName = v.videoName;
            nv.videoTitle = v.videoTitle; 
            nv.CourseId = v.CourseId;
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

        
        public string getCourseVideoName(int id)
        {
            CourseContext db = new CourseContext();
            Video v = db.Videos.First(p => p.ID == id);
            return v.videoName;
        }

        
        public bool deleteVideo(int id)
        {
            CourseContext db = new CourseContext();
            Video v = db.Videos.First(p => p.ID == id);
            db.Remove(v);
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

        public bool deleteCourseVideos(int id)
        {
            CourseContext db = new CourseContext();
            db.Videos.Where(p => p.CourseId == id).ToList().RemoveAll(r => true);
            int changedRows = db.SaveChanges();
            return true;
        }

        public int getCourseCount()
        {
            CourseContext db = new CourseContext();
            int count = db.Courses.Where(p => p.ID >= 1).Count();
            return count;
        }

        public int getApprovedCourseCount()
        {
            CourseContext db = new CourseContext();
            int count = db.Courses.Where(p => p.IsActive == true).Count();
            return count;
        }

        public int getPendingCourseCount()
        {
            CourseContext db = new CourseContext();
            int count = db.Courses.Where(p => p.IsActive == false).Count();
            return count;
        }

        public int getSellerCount()
        {
            CourseContext db = new CourseContext();
            int count = db.Sellers.Where(p => p.ID >= 1).Count();
            return count;
        }

        public int getApprovedSellerCount()
        {
            CourseContext db = new CourseContext();
            int count = db.Sellers.Where(p => p.IsActive == true).Count();
            return count;
        }

        public int getPendingSellerCount()
        {
            CourseContext db = new CourseContext();
            int count = db.Sellers.Where(p => p.IsActive == false).Count();
            return count;
        }

        public int getBuyerCount()
        {
            CourseContext db = new CourseContext();
            int count = db.Users.Where(p => p.ID >= 1).Count();
            return count;
        }

        public List<Course> getApprovedCourses()
        {
            CourseContext db = new CourseContext();
            List<Course> li = db.Courses.Where(p => p.IsActive == true).ToList();
            return li;
        }
        public List<Course> getPendingCourses()
        {
            CourseContext db = new CourseContext();
            List<Course> li = db.Courses.Where(p => p.IsActive == false).ToList();
            return li;
        }
        public List<Seller> getApprovedSellers()
        {
            CourseContext db = new CourseContext();
            List<Seller> li = db.Sellers.Where(p => p.IsActive == true).ToList();
            return li;
        }
        public List<Seller> getPendingSellers()
        {
            CourseContext db = new CourseContext();
            List<Seller> li = db.Sellers.Where(p => p.IsActive == false).ToList();
            return li;
        }

        public bool ApproveCourse(int id)
        {
            CourseContext db = new CourseContext();
            Course c = db.Courses.First(p => p.ID == id);
            c.IsActive = true;
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

        public bool UnApproveCourse(int id)
        {
            CourseContext db = new CourseContext();
            Course c = db.Courses.First(p => p.ID == id);
            c.IsActive = false;
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

        public List<Course> getSearchedCourses(string search)
        {
            CourseContext db = new CourseContext();
            List<Course> li = db.Courses.Where(p => p.IsActive == true && p.courseName.ToLower().Contains(search.ToLower())).ToList();
            return li;
        }
    }
}

