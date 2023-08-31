using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMS.Shared.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string FullName { get; set; }=string.Empty;
        [Column(TypeName = "varchar(100)")]

        public string? Email { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string? UserType { get; set; }
      
        [Column(TypeName = "text")]
        public string? Image { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }=string.Empty;
        [Column(TypeName = "varchar(max)")]
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsActive { get; set; }
    }
}
