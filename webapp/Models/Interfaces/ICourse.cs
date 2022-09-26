using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.Models.Interfaces
{
    public interface ICourse
    {
        public List<Course> getDevCourses();
        public Course getCourse(int id);
        public List<Course> getSellerCourses(int sid);
        public List<Video> getCourseVideos(int id);
        public Video getCourseVideo(int id);
    }
}