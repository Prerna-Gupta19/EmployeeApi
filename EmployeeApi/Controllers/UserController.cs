using EmployeeApi.Models;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("myCors")]
    public class UserController : ControllerBase
    {
        private IUService _userService;

        public UserController(IUService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UserDTO>> Get(UserDTO user)
        {
            var result = await _userService.Login(user);
            if (result != null)
                return Ok(result);
            MessageDTO messageDTO = new MessageDTO();
            messageDTO.Title = "Login Error";
            messageDTO.Description = "Invalid username or password";
            return BadRequest(messageDTO);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<UserDTO>> Post(UserDTO user)
        {
            var result = await _userService.Register(user);
            if (result != null)
                return Created("User registered", result);
            MessageDTO messageDTO = new MessageDTO();
            messageDTO.Title = "Login Error";
            messageDTO.Description = "Unable to register the user";
            return BadRequest(messageDTO);
        }


    }
}
