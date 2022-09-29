using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.Models.Interfaces
{
    public interface ISeller
    {
        public int insertData(Seller s);
        public bool getData(Seller s);
        public bool checkUsername(Seller s);
        public int addCourse(Course c);
        public int updateThumbnail(Course c);
        public int getSellerId(string uname);
        public int addVideo(Video v);
        public int updateVideoName(Video v);
        public bool ApproveSeller(int id);
        public bool UnApproveSeller(int id);
    }
}