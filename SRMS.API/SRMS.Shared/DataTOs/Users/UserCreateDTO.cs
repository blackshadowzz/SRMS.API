using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMS.Shared.DataTOs.Users
{
    public class UserCreateDTO
    {
        [StringLength(50)]
        public string FullName { get; set; } = string.Empty;
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(30)]
        public string? UserType { get; set; }
        public string? Image { get; set; }
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;
        [NotMapped]
        public string Password { get; set; } = string.Empty;
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
