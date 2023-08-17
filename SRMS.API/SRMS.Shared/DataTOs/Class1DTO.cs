using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMS.Shared.DataTOs
{
    public class Class1DTO
    {
        public int Id { get; set; }
        public string Test { get; set; } = string.Empty;
    }
    public class Class1CreateDTO
    {
        public string Test { get; set; } = string.Empty;
    }
    public class Class1UpdateDTO
    {
        public int Id { get; set; }
        public string Test { get; set; } = string.Empty;
    }
}
