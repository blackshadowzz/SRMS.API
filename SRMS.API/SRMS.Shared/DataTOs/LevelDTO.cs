using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMS.Shared.DataTOs
{
    public class LevelDTO
    {
        public int LevelId { get; set; }
        public string LevelName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
    public class LevelCreateDTO
    {
        [StringLength(30)]
        public string LevelName { get; set; } = string.Empty;
        [StringLength(50)]
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
    public class LevelUpdateDTO
    {
        public int LevelId { get; set; }
        [StringLength(30)]
        public string LevelName { get; set; } = string.Empty;
        [StringLength(50)]
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
