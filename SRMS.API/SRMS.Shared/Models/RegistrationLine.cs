﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Timers;

namespace SRMS.Shared.Models
{
    public class RegistrationLine
    {
        [Key]
        public int RegistrationLineId { get; set; }
        public int? RegistrationId { get; set; }
        public int? SubjectId { get; set; }
        public int? LevelId { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string? Durations { get; set; }
        [Column(TypeName = "varchar(10)")]

        public string? StartHour { get; set; }
        [Column(TypeName = "varchar(10)")]

        public string? EndHour { get; set; }
        public decimal? PricPer { get; set; }=Decimal.Zero;
        [ForeignKey(nameof(RegistrationId))]
        public Registration? Registration { get; set; }
    }
}
