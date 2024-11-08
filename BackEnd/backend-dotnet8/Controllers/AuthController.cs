using backend_dotnet8.Core.Dtos.Auth;
using backend_dotnet8.Core.Services.Interfaces;
using backend_dotnet8.DataLayer.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        //Seeding Roles
        [HttpPost]
        [Route("seed-roles")]
        public async Task<IActionResult> SeedRoles()
        {
            var seedResult = await _authService.SeedRolesAsync();
            return StatusCode(seedResult.StatusCode, seedResult.Message);
        }

        //Register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var registerResult = await _authService.RegisterAsync(registerDto);
            return StatusCode(registerResult.StatusCode, registerResult.Message);
        }

        //Login
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginServiceResponseDto>> Login([FromBody] LoginDto loginDto)  //LoginServiceResponseDto tokenti be front end ersal mikonad hamchenin daraye etelaate karbar mibashad
        {
            var loginResult = await _authService.LoginAsync(loginDto);

            if (loginResult is null)
            {
                return Unauthorized("Your credentials are invalid. Please contact to an Admin");
            }
            return Ok(loginResult);
        }

        //Update Roles
        [HttpPost]
        [Route("update-role")]
        [Authorize(Roles =StaticUserRoles.OwnerAdmin)]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleDto updateRoleDto)
        {
            var updateRoleResult = await _authService.UpdateRoleAsync(User, updateRoleDto);
            if (updateRoleResult.IsSucceed)
            {
                return Ok(updateRoleResult.Message);
            }
            else
            {
                return StatusCode(updateRoleResult.StatusCode, updateRoleResult.Message);
            }
        }

        //getting data of user from his JWT
        [HttpPost]
        [Route("me")]
        public async Task<ActionResult<LoginServiceResponseDto>> Me([FromBody] MeDto token)
        {
            try
            {
                var me = await _authService.MeAsync(token);
                if (me is not null)
                {
                    return Ok(me);
                }
                else
                {
                    return Unauthorized("Invalid Token");
                }
            }
            catch (Exception)
            {
                return Unauthorized("Invalid Token");
            }
        }

        //getting all users
        [HttpGet]
        [Route("users")]
        public async Task<ActionResult<IEnumerable<UserInfoResult>>> GetUsersList()
        {
            var usersList = await _authService.GetUsersListAsync();
            return Ok(usersList);
        }

        //get userdetails by username
        [HttpGet]
        [Route ("users/{userName}")]
        public async Task<ActionResult<UserInfoResult>> GetUserDetailByUserName([FromRoute]string userName)
        {
            var user = await _authService.GetUserDetailsByUserNameAsync(userName);
            if (user is not null)
                return Ok(user);
            else
                return NotFound("UserName not found");
        }

        //GET LIST OF ALL USERS(FORSENDING MESSAGES)
        [HttpGet]
        [Route("usernames")]
        public async Task<ActionResult<IEnumerable<string>>> GetUserNamesList()
        {
            var userNames=await _authService.GetUsernamesListAsync();
            return Ok(userNames);   
        }

    }
}
