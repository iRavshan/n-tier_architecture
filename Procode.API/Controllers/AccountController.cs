using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Procode.Domain;
using Procode.Service.Configuration;
using Procode.Service.DTO.Requests;
using Procode.Service.DTO.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Procode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;

        private readonly JwtConfig jwtConfig;

        public AccountController(UserManager<User> userManager, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            this.userManager = userManager;
            jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await userManager.FindByEmailAsync(user.Email);

                if (existingUser != null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() { "Email allaqachon ro'yxatga olingan" },
                        Succes = false
                    });
                }

                if(user.Password != user.ConfirmedPassword)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() { "Parol noto'g'ri tasdiqlandi" },
                        Succes = false
                    });
                }
                
                var newUser = new User() 
                { 
                    Email = user.Email, 
                    UserName = user.Username, 
                    RegisteredDateTime = DateTime.Now,
                    DisplayEmail = true
                };

                var isCreated = await userManager.CreateAsync(newUser, user.Password);

                if (isCreated.Succeeded)
                    {
                        var jwtToken = GenerateJwtToken(newUser);
                        return  BadRequest(new RegistrationResponse()
                        {
                            Succes = true,
                            Token = jwtToken
                        });

                    }
                else
                    {
                        return BadRequest(new RegistrationResponse()
                        {
                            Errors = isCreated.Errors.Select(x => x.Description).ToList(),
                            Succes = false
                        });
                    }
                
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string> { "Ma'lumotlar yaroqli emas" },
                Succes = false,

            });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await userManager.FindByEmailAsync(user.Email);

                if(existingUser == null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() { "Invalid login request" },
                        Succes = false
                    });
                }

                var isCorrect = await userManager.CheckPasswordAsync(existingUser, user.Password);

                if (!isCorrect)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() { "Invalid login request" },
                        Succes = false
                    });
                }

                var jwtToken = GenerateJwtToken(existingUser);

                return Ok(new RegistrationResponse()
                {
                    Succes = true,
                    Token = jwtToken
                });
            }

            return BadRequest(new RegistrationResponse()
            {
                 Errors = new List<string>() { "Invalid payload" },
                 Succes = false
            });
        }

        private string GenerateJwtToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.GivenName, user.UserName)
                }),

                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}
