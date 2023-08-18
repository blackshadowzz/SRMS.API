using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SRMS.API.Core.Services.RegistrationService;
using SRMS.Shared.DataTOs;
using SRMS.Shared.DataTOs.Registrations;
using SRMS.Shared.Models;
using SRMS.Shared.Respones;

namespace SRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationService service;
        private readonly IMapper mapper;
        private readonly ILogger<RegistrationsController> logger;

        public RegistrationsController(IRegistrationService service, IMapper mapper, ILogger<RegistrationsController> logger)
        {
            this.service = service;
            this.mapper = mapper;
            this.logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponeService<RegistrationDTO>>> Gets(string? q = null)
        {
            logger.LogInformation("Registration is listing...!");
            try
            {
                var results = await service.GetAllAsync();

                if (!string.IsNullOrWhiteSpace(q))
                {
                    results = results.Where(x => x.FullName.ToLower().StartsWith(q.ToLower())
                                        || x.NameInKhmer.ToLower().StartsWith(q.ToLower()));
                }
                var map = mapper.Map<IEnumerable<RegistrationDTO>>(results);
                if (map is null) return NotFound(new ResponeService<IEnumerable<RegistrationDTO>>()
                {
                    Success = false,
                    Message = "Not found!",
                    Data = Enumerable.Empty<RegistrationDTO>()

                });
                return Ok(new ResponeService<IEnumerable<RegistrationDTO>>()
                {
                    Success = true,
                    Message = "Registration listing",
                    Data = map

                });
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                return Problem(ex.Message, statusCode: 500);
            }
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponeService<RegistrationDTO>>> GetById(int id)
        {
            logger.LogInformation("Registration ...!");
            try
            {
                var result = await service.GetByIdAsync(id);
                var map = mapper.Map<RegistrationDTO>(result);
                if (map is null)
                    return BadRequest(new ResponeService<RegistrationDTO>()
                    {
                        Message = "Not found!",
                        Success = false,
                        Data = map ?? default!
                    });

                return Ok(new ResponeService<RegistrationDTO>()
                {
                    Success = true,
                    Data = map
                });
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                return Problem(ex.Message, statusCode: 500);
            }
        }
        [HttpGet("Line/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponeService<RegistrationLineDTO>>> GetLineById(int id)
        {
            logger.LogInformation("Registrationline ...!");
            try
            {
                var result = await service.GetLineByIdAsync(id);
                var map = mapper.Map<RegistrationLineDTO>(result);
                if (map is null)
                    return BadRequest(new ResponeService<RegistrationLineDTO>()
                    {
                        Message="Not found!",
                        Success = false,
                        Data = map??default!
                    });

                return Ok(new ResponeService<RegistrationLineDTO>()
                {
                    Success = true,
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
        public async Task<ActionResult<ResponeService<bool>>> CreateLevel([FromBody] RegistrationCreateDTO registration)
        {
            logger.LogInformation("Registration is creating...!");
            try
            {

                var result = mapper.Map <Registration>(registration);
                var created = await service.CreateAsync(result);

                if (created == false)
                    return BadRequest(new ResponeService<bool>()
                    {
                        Message = "Cannot create registration",
                        Success = false,
                        Data = false
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
