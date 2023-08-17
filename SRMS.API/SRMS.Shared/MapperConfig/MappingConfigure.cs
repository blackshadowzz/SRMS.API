using AutoMapper;
using SRMS.Shared.DataTOs;
using SRMS.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMS.Shared.MapperConfig
{
    public class MappingConfigure : Profile
    {
        public MappingConfigure()
        {
            CreateMap<Class1,Class1DTO>().ReverseMap();
            CreateMap<Class1,Class1CreateDTO>().ReverseMap();
            CreateMap<Class1,Class1UpdateDTO>().ReverseMap();
        }
    }
}
