using Logistica.Application.Interfaces;
using Logistica.Infraestructure.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Logistica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticate _authentication;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(IConfiguration configuration, IAuthenticate authentication, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));

            _authentication = authentication ??
                throw new ArgumentNullException(nameof(authentication));
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] RegisterUserModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "As senhas não conferem");
                return BadRequest(ModelState);
            }

            var result = await _authentication.RegisterUser(model.FirstName,model.LastName,model.Email, model.Password);
            
            if (result)
            {
                return Ok($"Usuário {model.FirstName} criado com sucesso");
            }
            else
            {
                ModelState.AddModelError("CreateUser", $"Registro inválido.{result}");
                return BadRequest(ModelState);
            }
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> LoginUser([FromBody] LoginUserModel userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            }

            var result = await _authentication.Authenticate(userInfo.UserName, userInfo.Password);

            if (result)
            {
                return GenerateToken(userInfo);
            }
            else
            {
                ModelState.AddModelError("LoginUser", $"Login inválido.{result}");
                return BadRequest(ModelState);
            }
        }

        private ActionResult<UserToken> GenerateToken(LoginUserModel userInfo)
        {
            var claims = new[]
            {
                new Claim("email", userInfo.UserName),
                new Claim("meuToken", "token do marco"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(20);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: _configuration["Jwt:Issuer"],
               audience: _configuration["Jwt:Audience"],
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
            };
        }
    }
}
