using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SRMS.API.Core.Services.Class1Service;
using SRMS.Shared.DataTOs;
using SRMS.Shared.Models;
using SRMS.Shared.Respones;

namespace SRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Class1sController :ControllerBase
    {
        private readonly IClassService service;
        private readonly ILogger<Class1sController> logger;
        private readonly IMapper mapper;

        public Class1sController(IClassService service, ILogger<Class1sController> logger, IMapper mapper)
        {
            this.service = service;
            this.logger = logger;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponeService<Class1DTO>>> Gets(string? q = null)
        {
            logger.LogInformation("Attendance is listing...!");
            try
            {
                var results = await service.GetAllAsync();
                
                if (!string.IsNullOrWhiteSpace(q))
                {
                    results = results.Where(x => x.Test.ToLower().StartsWith(q.ToLower()));
                }
                var map = mapper.Map<IEnumerable<Class1DTO>>(results);
                if (map is null) return NotFound(new ResponeService<IEnumerable<Class1DTO>>()
                {
                    Success=false,
                    Message="Not found!",
                    Data=Enumerable.Empty<Class1DTO>()

                });
                return Ok(new ResponeService<IEnumerable<Class1DTO>>()
                {
                    Success = true,
                    Message = "Class listing",
                    Data = map

                });
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                return Problem(ex.Message, statusCode: 500);
            }
        }
        [HttpPost]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ResponeService<bool>>> CreateAttendance([FromBody] Class1CreateDTO class1)
        {
            logger.LogInformation("Class is creating...!");
            try
            {

                var stu = mapper.Map<Class1>(class1);
                var createStu = await service.CreateAsync(stu);

                if (createStu == false)           
                    return BadRequest(new ResponeService<bool>()
                    {
                        Message="Cannot create class1",
                        Success=false,
                        Data=false
                    });
     
                return Ok(new ResponeService<bool>()
                {
                    Message = "Created Successfully",
                    Success = true,
                    Data = true
                });
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                return Problem(ex.InnerException.Message, statusCode: 500);
            }
        }
    }
}
