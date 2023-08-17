﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMS.Shared.Respones
{
    public class ResponeService<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }=true;
        public string Message { get; set; }=string.Empty;
    }
}
