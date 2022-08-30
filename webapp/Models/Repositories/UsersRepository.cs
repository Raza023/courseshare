using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Models.Interfaces;

namespace webapp.Models.Repositories
{
    public class UsersRepository: IUsers
    {
        public int insertData(Users u)
        {
            // string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=first;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            // SqlConnection con = new SqlConnection(conStr);
            // con.Open();

            // SqlParameter p1 = new SqlParameter("N", u.Name);
            // SqlParameter p2 = new SqlParameter("E", u.Email);
            // SqlParameter p3 = new SqlParameter("U", u.Username);
            // SqlParameter p4 = new SqlParameter("P", u.Password);
            // string query = "Insert into USERS (name,email,username,password) values (@N,@E,@U,@P)";
            // SqlCommand cmd = new SqlCommand(query,con);
            // cmd.Parameters.Add(p1);
            // cmd.Parameters.Add(p2);
            // cmd.Parameters.Add(p3);
            // cmd.Parameters.Add(p4);

            // int count = cmd.ExecuteNonQuery();
            
            // if (count>=1)
            // {
            //     con.Close();
            //     return true;
            // }
            // else
            // {
            //     con.Close();
            //     return false;
            // }

            // Product p = new Product();
            // p.Name = "Cycle";
            // p.Price = 2500;

            // db.Products.Add(p);

            CourseContext db = new CourseContext();
            db.Users.Add(u);
            int writtenEntriesCount = db.SaveChanges();
            if(writtenEntriesCount > 0)
            {
                // is saved
                return u.ID;
            }
            else
            {
                // is not saved
                return 0;
            }
        }

        

        public bool getData(Users u)
        {
            // string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=first;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            // SqlConnection con = new SqlConnection(conStr);
            // con.Open();

            // SqlParameter p1 = new SqlParameter("U", u.Username);
            // SqlParameter p2 = new SqlParameter("P", u.password);
            // string query = "select * from Users where username = @U and password = @P";
            // SqlCommand cmd = new SqlCommand(query, con);
            // cmd.Parameters.Add(p1);
            // cmd.Parameters.Add(p2);

            // SqlDataReader dr = cmd.ExecuteReader();

            // if (dr.HasRows)
            // {
            //     con.Close();
            //     return true;
            // }
            // else
            // {
            //     con.Close();
            //     return false;
            // }

            CourseContext db = new CourseContext();
            List<Users> li = db.Users.Where(p => p.Username==u.Username && p.Password == u.Password).ToList();
            if(li.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }        
        }

        public bool checkUsername(Users u)
        {
            // string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=first;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            // SqlConnection con = new SqlConnection(conStr);
            // con.Open();

            // SqlParameter p1 = new SqlParameter("U", u.Username);
            // string query = "select * from Users where username = @U";
            // SqlCommand cmd = new SqlCommand(query, con);
            // cmd.Parameters.Add(p1);

            // SqlDataReader dr = cmd.ExecuteReader();

            // if (dr.HasRows)
            // {
            //     con.Close();
            //     return true;
            // }
            // else
            // {
            //     con.Close();
            //     return false;
            // }

            CourseContext db = new CourseContext();
            List<Users> li = db.Users.Where(p => p.Username==u.Username && p.Email == u.Email).ToList();
            if(li.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SendEmail(string name, string email, string subject, string message)
        {
            string status = "";
            try
            {
                string from="imhraza023@gmail.com";
                string password = "vkhmbryvwbzmrfko";//watch this to get your app password  https://youtu.be/J4CtP1MBtOE
                string sub = subject+" - CourseShare";
                string title="CourseShare";       //title of prjoect.

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add("imhraza023@gmail.com");
                mail.Subject = sub;
                mail.Body = "<center><h1>"+title+"</h1></center><h3>From: "+name+" - "+email+"</h3><h3>Message:<h3/><p>"+message+"</p>";
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
                smtp.Credentials = new System.Net.NetworkCredential(from,password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
                status = "Mail Sent";
            }
            catch(Exception ex)
            {
                status = ex.Message;
            }
            if(status == "Mail Sent")
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