using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace webapp.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string courseName { get; set; }
        public string courseDescription { get; set; }
        public string courseThumbnail { get; set; }
        public string coursePath { get; set; }
        public string videos { get; set; }
    }
}

