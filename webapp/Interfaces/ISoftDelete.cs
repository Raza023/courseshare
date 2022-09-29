using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace webapp.Interfaces
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}