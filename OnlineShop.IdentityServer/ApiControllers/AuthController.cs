using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.IdentityServer.Data;
using OnlineShop.IdentityServer.Models;
using OnlineShop.Infrastructure.Constants;
using RestSharp;

namespace OnlineShop.IdentityServer.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dataContext;
        private readonly IConfiguration _configuration;
        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext dataContext,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dataContext = dataContext;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(request.Username, request.Password, true, true);

            if (!signInResult.Succeeded)
            {
                return BadRequest("Invalid user name or password");
            }

            var user = await _userManager.FindByNameAsync(request.Username);
            var accessToken = GetToken(user.Id, 3600);

            var refreshToken = GetToken(user.Id, 3600);

            var result = new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
                
            }
            result = await _userManager.AddToRoleAsync(user, model.Roles.ToString());
            if (!result.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return BadRequest(result.Errors);
            }
            result = await _userManager.AddClaimsAsync(user, new Claim[]{
                            new Claim(JwtClaimTypes.Name, model.DescriptionEn),
                            new Claim(JwtClaimTypes.GivenName, model.DescriptionAr),
                            new Claim(JwtClaimTypes.Email, model.Username),
                            new Claim(JwtClaimTypes.Id, user.Id),
                        });
            if (!result.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return BadRequest(result.Errors);
            }
            var client = new RestClient($"{_configuration.GetValue<string>("apiUrl")}/customer");
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(new CreateCustomerModel
            {
                DescriptionAr = model.DescriptionAr,
                DescriptionEn = model.DescriptionEn,
                UserId = user.Id
            });
            var response = client.Execute(request);
            return Ok(true);
        }
    
    private string GetToken(string id, int expiration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("secret");
            var sKey = new SymmetricSecurityKey(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim( ClaimTypes.UserData,
                    "IsValid", ClaimValueTypes.String, "(local)" )
                }),
                Issuer = "self",
                Audience = "http://localhost:53132",
                Expires = DateTime.Now.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("secret")), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);

            return accessToken;
        }
    }

}
