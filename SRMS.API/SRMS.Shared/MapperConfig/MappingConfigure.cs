using AutoMapper;
using SRMS.Shared.DataTOs;
using SRMS.Shared.DataTOs.Registrations;
using SRMS.Shared.Models;

namespace SRMS.Shared.MapperConfig
{
    public class MappingConfigure : Profile
    {
        public MappingConfigure()
        {
            CreateMap<Class1,Class1DTO>().ReverseMap();
            CreateMap<Class1,Class1CreateDTO>().ReverseMap();
            CreateMap<Class1,Class1UpdateDTO>().ReverseMap();

            CreateMap<Level,LevelDTO>().ReverseMap();
            CreateMap<Level,LevelCreateDTO>().ReverseMap();
            CreateMap<Level,LevelUpdateDTO>().ReverseMap();

            CreateMap<Registration,RegistrationDTO>().ReverseMap();
            CreateMap<Registration,RegistrationCreateDTO>().ReverseMap();
            CreateMap<Registration,RegistrationUpdateDTO>().ReverseMap();

            CreateMap<RegistrationLine,RegistrationLineDTO>().ReverseMap();
            CreateMap<RegistrationLine,RegistrationLineCreateDTO>().ReverseMap();
            CreateMap<RegistrationLine,RegistrationLineUpdateDTO>().ReverseMap();
      

        }
    }
}
