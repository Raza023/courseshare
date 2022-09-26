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
    }
}

