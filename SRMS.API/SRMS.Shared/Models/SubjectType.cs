using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMS.Shared.Models
{
    public class SubjectType
    {
        [Key]
        public int TypeId { get; set; }
        [Column(TypeName="varchar(50)")]
        public string TypeName { get; set; } = string.Empty;
        [Column(TypeName="nvarchar(100)")]
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
