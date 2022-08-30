using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.Models.Interfaces
{
    public interface IUsers
    {
        public int insertData(Users u);
        public bool getData(Users u);
        public bool checkUsername(Users u);
        public bool SendEmail(string name, string email, string subject, string message);
    }
}