using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SRMS.API.Core.Services.LevelService;
using SRMS.Shared.DataTOs;
using SRMS.Shared.Models;
using SRMS.Shared.Respones;

namespace SRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly ILevelService service;
        private readonly IMapper mapper;
        private readonly ILogger<LevelsController> logger;

        public LevelsController(ILevelService service, IMapper mapper, ILogger<LevelsController> logger)
        {
            this.service = service;
            this.mapper = mapper;
            this.logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponeService<LevelDTO>>> Gets(string? q = null)
        {
            logger.LogInformation("Attendance is listing...!");
            try
            {
                var results = await service.GetAllAsync();

                if (!string.IsNullOrWhiteSpace(q))
                {
                    results = results.Where(x => x.LevelName.ToLower().StartsWith(q.ToLower()));
                }
                var map = mapper.Map<IEnumerable<LevelDTO>>(results);
                if (map is null) return NotFound(new ResponeService<IEnumerable<LevelDTO>>()
                {
                    Success = false,
                    Message = "Not found!",
                    Data = Enumerable.Empty<LevelDTO>()

                });
                return Ok(new ResponeService<IEnumerable<LevelDTO>>()
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
        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponeService<LevelDTO>>> Gets(int id)
        {
            logger.LogInformation("Attendance is listing...!");
            try
            {
                var results = await service.GetByIdAsync(id);
                var map = mapper.Map<IEnumerable<LevelDTO>>(results);
                if (map is null) return NotFound(new ResponeService<IEnumerable<LevelDTO>>()
                {
                    Success = false,
                    Message = "Not found!",
                    Data = Enumerable.Empty<LevelDTO>()

                });
                return Ok(new ResponeService<IEnumerable<LevelDTO>>()
                {
                    Success = true,
                    Message = "Data found!",
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
        public async Task<ActionResult<ResponeService<bool>>> CreateLevel([FromBody] LevelCreateDTO level)
        {
            logger.LogInformation("Class is creating...!");
            try
            {

                var stu = mapper.Map<Level>(level);
                var createStu = await service.CreateAsync(stu);

                if (createStu == false)
                    return BadRequest(new ResponeService<bool>()
                    {
                        Message = "Cannot create level",
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
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponeService<bool>>> UpdateStudent(int id, LevelUpdateDTO model)
        {
            logger.LogInformation("Level is updating...!");

            try
            {
                var result = await service.GetByIdAsync(id);
                if (result is null)
                    return BadRequest(new ResponeService<bool>()
                    {
                        Message = "Data not found!",
                        Success = false,
                        Data = false
                    });
                var map = mapper.Map<Level>(model);
                if (await service.UpdateAsync(map))
                    return Ok(new ResponeService<bool>()
                    {
                        Message = "Updated Successfully",
                        Success = true,
                        Data = true
                    });
                return BadRequest(new ResponeService<bool>()
                {
                    Message = "Cannot update level",
                    Success = false,
                    Data = false
                });
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                return Problem(ex.InnerException.Message, statusCode: 500);
            }
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ResponeService<bool>>> DeleteLevel(int id)
        {
            logger.LogInformation("Level is updating...!");

            try
            {
                var result = await service.GetByIdAsync(id);
                if (result is null)
                    return BadRequest(new ResponeService<bool>()
                    {
                        Message = "Data not found!",
                        Success = false,
                        Data = false
                    });
                if (await service.DeleteAsync(id))
                    return Ok(new ResponeService<bool>()
                    {
                        Message = "Deleted Successfully",
                        Success = true,
                        Data = true
                    });
                return BadRequest(new ResponeService<bool>()
                {
                    Message = "Cannot delete level",
                    Success = false,
                    Data = false
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
