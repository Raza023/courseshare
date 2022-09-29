using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using webapp.Interfaces;

namespace webapp.Models
{
    public abstract class CourseAuditModel : IIdentityModel, IAuditedModel, IActivateModel, ISoftDelete
    {
        [Key]
        public int ID { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedUserId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}