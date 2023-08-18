using SRMS.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMS.Shared.DataTOs.Registrations
{
    public class RegistrationCreateDTO
    {
        public RegistrationCreateDTO()
        {
            RegistrationLines = new List<RegistrationLineCreateDTO>();
        }
        public int RegistrationId { get; set; }
        [StringLength(50)]
        public string FullName { get; set; } = string.Empty;
        [StringLength(100)]
        public string? NameInKhmer { get; set; }
        [StringLength(20)]
        public string? Sex { get; set; }
        public DateTime? DateofBirth { get; set; }
        [StringLength(20)]
        public string? PhoneNo { get; set; }
        [StringLength(50)]
        public string? Telegram { get; set; }
        public DateTime RegistrationDated { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public List<RegistrationLineCreateDTO> RegistrationLines { get; set; }
    }
}
