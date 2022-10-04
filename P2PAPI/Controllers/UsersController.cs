using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using P2P.Services;
using System.Threading.Tasks;
using Entities;
using Microsoft.Extensions.Configuration;
using P2P.DTO.Input;
using P2P.DTO.Output;
using Microsoft.AspNetCore.Authorization;

namespace P2P.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IUsersService _userServices;
        private readonly ITokenService _tokenService;
        private string generatedToken = null;

        public UsersController(IConfiguration config, ITokenService tokenService, IUsersService userServices)
        {
            _config = config;
            _tokenService = tokenService;
            _userServices = userServices;
        }

        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(UserIDTO userModel)
        {
            if (string.IsNullOrEmpty(userModel.Username) || string.IsNullOrEmpty(userModel.Password))
            {
                return (BadRequest("Json does not have username and password"));
            }
            var validUser = _userServices.GetUser(userModel);

            if (validUser != null)
            {
                generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), validUser);
                if (generatedToken != null)
                {
                    HttpContext.Session.SetString("Token", generatedToken);
                    return Ok(new { user = validUser, token = generatedToken });
                }
                else return BadRequest("Token could not be generated");
            }
            else return Unauthorized("No user found");
        }

        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public IActionResult Register(UserIDTO userModel)
        {
            if (string.IsNullOrEmpty(userModel.Username) || string.IsNullOrEmpty(userModel.Password) || string.IsNullOrEmpty(userModel.Role))
                return BadRequest("User must have all data assigned");

            var user = _userServices.RegisterUser(userModel);
            return Ok(user);
        }

        [Authorize]
        [Route("GetUserbyId")]
        [HttpGet]
        public IActionResult GetUserbyId(int id)
        {
            var user = _userServices.GetUserById(id);
            return Ok(user);
        }
    }
}