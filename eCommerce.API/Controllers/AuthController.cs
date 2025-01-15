using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.DTO;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")] //api/auth
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersServices;
        public AuthController(IUsersService usersServices)
        {
            _usersServices = usersServices;
        }

        [HttpPost("register")] //POST api/auth/register
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if(registerRequest == null)
                return BadRequest("Invalid registration data");

            AuthenticationResponse? result = await _usersServices.Register(registerRequest);

            if (result == null || !result.Success)
                return BadRequest(result);

            return Ok(result);

        }
        [HttpPost("login")] //POST api/auth/login
        public async Task<IActionResult?> Login(LoginRequest loginRequest)
        {
            if(loginRequest == null)
                return BadRequest("Invalid login data");

            AuthenticationResponse? authenticationResponse = await _usersServices.Login(loginRequest);

            if (authenticationResponse == null || !authenticationResponse.Success)
                return Unauthorized(authenticationResponse);

            return Ok(authenticationResponse);


        }   
    }
}
