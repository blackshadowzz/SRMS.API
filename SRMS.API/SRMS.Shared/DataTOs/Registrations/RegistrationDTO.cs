using SRMS.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMS.Shared.DataTOs.Registrations
{
    public class RegistrationDTO
    {
        public int RegistrationId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FullName { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(100)")]
        public string? NameInKhmer { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Sex { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? DateofBirth { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? PhoneNo { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Telegram { get; set; }
        public DateTime RegistrationDated { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        public List<RegistrationLine> RegistrationLines { get; set; } = new List<RegistrationLine>();
    }
}
