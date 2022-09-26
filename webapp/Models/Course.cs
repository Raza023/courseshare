using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace webapp.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string courseName { get; set; }
        public string courseDescription { get; set; }
        public string courseThumbnail { get; set; }
        public string category { get; set; }

        public int SellerId { get; set; }
        [ForeignKey("SellerId")]
        public virtual Seller Seller { get; set; }

        public virtual List<Video> Videos { get; set; } = new List<Video>();
    }
}

