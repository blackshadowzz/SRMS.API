using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRMS.API.Core.Services.UserServices;
using SRMS.Shared.DataTOs;
using SRMS.Shared.DataTOs.Users;
using SRMS.Shared.Models;
using SRMS.Shared.Respones;

namespace SRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService service;
        private readonly ILogger<UsersController> logger;
        private readonly IMapper mapper;

        public UsersController(IUserService service, ILogger<UsersController> logger, IMapper mapper)
        {
            this.service = service;
            this.logger = logger;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Gets()
        {
            logger.LogInformation("Users is listing...!");
            try
            {
                var results = await service.GetAllAsync();

               
                var map = mapper.Map<IEnumerable<UserDTO>>(results);
                if (map is null) return NotFound("Not found");
                return Ok(map);
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
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            logger.LogInformation("User is found...!");
            try
            {
                var result = await service.GetByIdAsync(id);
                var map = mapper.Map<UserDTO>(result);
                if (map is null) return NotFound();
                return Ok(map);
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
        public async Task<ActionResult<ResponeService<int>>> UserRegister([FromBody] UserCreateDTO user)
        {
            logger.LogInformation("User is registering...!");
            try
            {

                var mapped = mapper.Map<User>(user);
                var created = await service.RegisterAsync(mapped, user.Password);
                //var remapped = mapper.Map<UserDTO>(created);
                if (created.Success==false)
                    return BadRequest(created);

                return Ok(created);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                return Problem(ex.InnerException.Message, statusCode: 500);
            }
        }
        [HttpPost("Login")]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ResponeService<string>>> UserLogin(UserLoginDTO user)
        {
            logger.LogInformation("User is login...!");
            try
            {

                var login = await service.UserLogin(user.Username, user.Password);

                if (!login.Success)
                    return BadRequest(login);

                return Ok(login);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                return Problem(ex.InnerException.Message, statusCode: 500);
            }
        }
        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<ResponeService<bool>>> UpdateStudent(int id, LevelUpdateDTO model)
        //{
        //    logger.LogInformation("Level is updating...!");

        //    try
        //    {
        //        var result = await service.GetByIdAsync(id);
        //        if (result is null)
        //            return BadRequest(new ResponeService<bool>()
        //            {
        //                Message = "Data not found!",
        //                Success = false,
        //                Data = false
        //            });
        //        var map = mapper.Map<Level>(model);
        //        if (await service.UpdateAsync(map))
        //            return Ok(new ResponeService<bool>()
        //            {
        //                Message = "Updated Successfully",
        //                Success = true,
        //                Data = true
        //            });
        //        return BadRequest(new ResponeService<bool>()
        //        {
        //            Message = "Cannot update level",
        //            Success = false,
        //            Data = false
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogInformation(ex.Message);
        //        return Problem(ex.InnerException.Message, statusCode: 500);
        //    }
        //}
        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(500)]
        //[ProducesResponseType(400)]
        //public async Task<ActionResult<ResponeService<bool>>> DeleteLevel(int id)
        //{
        //    logger.LogInformation("Level is updating...!");

        //    try
        //    {
        //        var result = await service.GetByIdAsync(id);
        //        if (result is null)
        //            return BadRequest(new ResponeService<bool>()
        //            {
        //                Message = "Data not found!",
        //                Success = false,
        //                Data = false
        //            });
        //        if (await service.DeleteAsync(id))
        //            return Ok(new ResponeService<bool>()
        //            {
        //                Message = "Deleted Successfully",
        //                Success = true,
        //                Data = true
        //            });
        //        return BadRequest(new ResponeService<bool>()
        //        {
        //            Message = "Cannot delete level",
        //            Success = false,
        //            Data = false
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogInformation(ex.Message);
        //        return Problem(ex.InnerException.Message, statusCode: 500);
        //    }
        //}
    }
}
