using SRMS.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMS.Shared.DataTOs.Registrations
{
    public class RegistrationLineUpdateDTO
    {
        public int RegistrationLineId { get; set; }
        public int? RegistrationId { get; set; }
        public int? SubjectId { get; set; }
        public int? LevelId { get; set; }
        public string? Durations { get; set; }
        public string? StartHour { get; set; }
        public string? EndHour { get; set; }
        public decimal? PricPer { get; set; }
    }
}
