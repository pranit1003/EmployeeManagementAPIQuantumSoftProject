using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementAPIQuantumSoft.Interfaces;

namespace EmployeeManagementAPIQuantumSoft.Controllers
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


        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password, int roleId)
        {
            var result = await _authService.Register(username, password, roleId);
            if (result == "User already exists.")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var token = await _authService.Login(username, password);
            if (token == "Invalid username or password.")
                return Unauthorized(token);

            return Ok(new { token });
        }
    }
}
