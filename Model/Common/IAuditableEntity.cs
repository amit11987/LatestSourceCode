using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    public interface IAuditableEntity 
    {
        DateTime CreatedDate { get; set; }
     
        long CreatedBy { get; set; }

        DateTime UpdatedDate { get; set; }

        long UpdatedBy { get; set; }

        bool IsActive { get; set; }
    }
}
