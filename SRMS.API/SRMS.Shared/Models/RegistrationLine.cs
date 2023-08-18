using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMS.Shared.Models
{
    public class RegistrationLine
    {
        [Key]
        public int RegistrationLineId { get; set; }
        public int? RegistrationId { get; set; }
        public int? SubjectId { get; set; }
        public int? LevelId { get; set; }
        public string? Durations { get; set; }
        public DateTime? StartHour { get; set; }
        public DateTime? EndHour { get; set; }
        public decimal? PricPer { get; set; }
        [ForeignKey(nameof(RegistrationId))]
        public Registration? Registration { get; set; }
    }
}
