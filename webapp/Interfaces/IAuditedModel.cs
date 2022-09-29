using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace webapp.Interfaces
{
    public interface IAuditedModel
{
    public string CreatedByUserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastModifiedUserId { get; set; }
    public DateTime LastModifiedDate { get; set; }
}
}