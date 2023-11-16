using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.TransferModels;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace api.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController (UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("/api/users")]
        public ResponseDto GetAllUsers()
        {
            return new ResponseDto()
            {
                MessageToClient = "Here are all the users!"
            };
        }
        
    }
}