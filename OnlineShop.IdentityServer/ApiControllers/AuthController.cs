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
        private readonly IConfiguration _configuration;
        private readonly JwtHandler _jwtHandler;
        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
                return Unauthorized(new AuthResponseModel { ErrorMessage = "Invalid Authentication" });
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthResponseModel { IsAuthSuccessful = true, Token = token });
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
    }

}
