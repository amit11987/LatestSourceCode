using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity    
    {
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        public long CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime UpdatedDate { get; set; }

        [ScaffoldColumn(false)]
        public long UpdatedBy { get; set; }

        [ScaffoldColumn(false)]
        public bool IsActive { get; set; }
    }
}
