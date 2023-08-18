using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMS.Shared.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Column(TypeName ="nvarchar(100)")]

        public string SubjectName { get; set; } = string.Empty;
        [Column(TypeName = "varchar(50)")]

        public string? Duration { get; set; }
        [Column(TypeName = "varchar(15)")]

        public string? SubjectCode { get; set; }
        [Column(TypeName = "nvarchar(200)")]

        public string? Description { get; set; }
        public int? TypeId { get; set; }
    }
}
