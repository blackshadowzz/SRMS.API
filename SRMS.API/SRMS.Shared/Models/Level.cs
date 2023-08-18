using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMS.Shared.Models
{
    public class Level
    {
        [Key]
        public int LevelId { get; set; }
        [Column(TypeName ="varchar(30)")]
        public string LevelName { get; set; }  = string.Empty;
        [Column(TypeName ="nvarchar(50)")]
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
