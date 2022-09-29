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
        public List<Course> getSearchedCourses(string search);
        public List<Course> getDevCourses();
        public List<Course> getDevelopmentCourses();
        public List<Course> getPhotographyCourses();
        public List<Course> getTeachingCourses();
        public List<Course> getDesignCourses();
        public List<Course> getHealthCourses();
        public List<Course> getBusinessCourses();
        public Course getCourse(int id);
        public List<Course> getSellerCourses(int sid);
        public List<Video> getCourseVideos(int id);
        public Video getCourseVideo(int id);
        public bool deleteCourse(int id);
        public string getCourseThumbnailName(int id);
        public bool updateCourse(int id, Course c);
        public string getCourseVideoName(int id);
        public bool deleteVideo(int id);
        public bool updateVideo(int id, Video v);
        public bool deleteCourseVideos(int id);
        public int getCourseCount(); 
        public int getApprovedCourseCount();
        public int getPendingCourseCount();
        public int getSellerCount();
        public int getApprovedSellerCount();
        public int getPendingSellerCount();
        public int getBuyerCount();
        public List<Course> getApprovedCourses();
        public List<Course> getPendingCourses();
        public List<Seller> getApprovedSellers();
        public List<Seller> getPendingSellers();
        public bool ApproveCourse(int id);
        public bool UnApproveCourse(int id);
    }
}