using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace webapp.Models
{
    public class Users: CourseAuditModel
    {
        // int? or float? to make nullable 

        // public int ID { get; set; }

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

        
    }
}