using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.Authentication.Models.DTO;
using Restaurant.Services.Authentication.Service;

namespace Restaurant.Services.Authentication.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDTO response;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            response = new ResponseDTO();
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO registrationRequestDTO)
        {
            var errorMessage = await _authService.Register(registrationRequestDTO);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                response.Success = false;
                response.DisplayMessage = errorMessage;
                return BadRequest(errorMessage);

            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var loginResponse = await _authService.Login(loginRequestDTO);
            if(loginResponse == null) {
                response.Success = false;
                response.DisplayMessage = "Username or Password incorrect";
                return BadRequest(response);

            }
            response.Result = loginResponse;
            return Ok(response);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDTO registrationRequestDTO)
        {
            var assignRoleSucessful = await _authService.AssignRole(registrationRequestDTO.Email, registrationRequestDTO.Role.ToUpper());
            if(!assignRoleSucessful)
            {
                response.Success = false;
                response.DisplayMessage = "Couldn't assign Role";
                return BadRequest(response);
            }
            return Ok(response);

        }

    }
}
