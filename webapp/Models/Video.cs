using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace webapp.Models
{
    public class Video: CourseAuditModel
    {
        // public int ID { get; set; }
        public string videoName { get; set; }
        public string videoTitle { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}