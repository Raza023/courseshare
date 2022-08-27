using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace webapp.Models
{
    public class Users
    {
        // int? or float? to make nullable 

        private string name;
        [Required(ErrorMessage = "Please Enter correct name")]
        [Display(Name = "Enter your name")]
        [StringLength(100)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string email;
        [Required(ErrorMessage = "Please Enter correct email")]
        [Display(Name = "Enter your Email")]
        [EmailAddress]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string username;
        [Required(ErrorMessage = "Please Enter correct username")]
        [Display(Name = "Enter your username")]
        [StringLength(100)]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private string password;
        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [Required(ErrorMessage = "Confirmation Password is Required...")] 
        [Compare("Password", ErrorMessage = "Password Must Match")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public bool insertData(Users u)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=first;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlParameter p1 = new SqlParameter("N", u.Name);
            SqlParameter p2 = new SqlParameter("E", u.Email);
            SqlParameter p3 = new SqlParameter("U", u.Username);
            SqlParameter p4 = new SqlParameter("P", u.Password);
            string query = "Insert into USERS (name,email,username,password) values (@N,@E,@U,@P)";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);

            int count = cmd.ExecuteNonQuery();
            
            if (count>=1)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }

        public bool getData(Users u)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=first;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlParameter p1 = new SqlParameter("U", u.Username);
            SqlParameter p2 = new SqlParameter("P", u.password);
            string query = "select * from Users where username = @U and password = @P";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }

        public bool checkUsername(Users u)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=first;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlParameter p1 = new SqlParameter("U", u.Username);
            string query = "select * from Users where username = @U";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
    }
}