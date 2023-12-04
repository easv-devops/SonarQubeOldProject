using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.TransferModels;
using api.TransferModels.AuthenticateDto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace api.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ResponseDto RegisterUser([FromBody] RegisterUserDto dto)
        {
            return new ResponseDto()
            {
                MessageToClient = "User registered successfully!",
                ResponseData = _userService.CreateUser(dto.Username!, dto.Email!, dto.Password!, dto.ShortDescription!) 
            };
        }
        [HttpPost("login")]
        public ResponseDto Login([FromBody] LoginDto dto)
        {
            return new ResponseDto()
            {
                MessageToClient = "Login successful!",
                ResponseData = _userService.AuthenticateUser(dto.Username!, dto.Password!)
            };
        }
    }
}