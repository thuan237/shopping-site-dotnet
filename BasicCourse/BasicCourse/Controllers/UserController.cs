using BasicCourse.Data;
using BasicCourse.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace BasicCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly AppSettings _appSetting;
        public UserController(MyDbContext context, IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _context = context;
            _appSetting = optionsMonitor.CurrentValue;

        }

        [HttpPost("Login")]
        public IActionResult Validate(LoginModel loginModel)
        {
            var user = _context.Users.SingleOrDefault(p => p.username == loginModel.username && p.password == loginModel.password);
            if (user == null)
            {
                return Ok(new ApiResponse
                {
                    Success = false,
                    Message = "Invalid username/ password"
                });
            }

            // cấp token
            

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Authenticate success",
                Data = token
            });
        }
        private string GenerateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

        }
    }
}
