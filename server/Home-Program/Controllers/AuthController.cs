using Home_Program.Model.User;
using Home_Program.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Home_Program.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            return await _authService.Register(model);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            return await _authService.Login(model);
        }
    }

}
