using BigBangAssessment.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BigBangAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly AuthenticateDbContext auth;
        public AuthenticateController(AuthenticateDbContext adb, IConfiguration ic)
        {
            this.auth = adb;
            this.configuration = ic;

        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterUser r)
        {

            var user = new RegisterUser()
            {
                Username = r.Username,
                Password = r.Password,
                Email = r.Email,
                Role = r.Role,

            };
            auth.Add(user);
            auth.SaveChanges();
            return Ok(user);


        }
        [HttpPost("Login")]
        public async Task<ActionResult> SignIn(LoginUser u)
        {
            string uname = u.Username;
            string pass = u.Password;
            var user = auth.RegisterUser.FirstOrDefault(x => x.Username == uname);
            if (user != null && user.Password == u.Password)
            {
                var token = CreatToken(user);
                return Ok(new { token, user });
            }
            else
            {
                return BadRequest("user not found");
            }
        }

        private string CreatToken(RegisterUser r)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, r.Username),
                new Claim(ClaimTypes.Role,r.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSetting:Token").Value!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
