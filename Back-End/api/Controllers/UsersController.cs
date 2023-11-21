using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.TransferModels;
using Core.Enteties;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace api.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly UserService _userService;

        public UsersController (UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ResponseDto GetAllUsers()
        {

            return new ResponseDto()
            {
                MessageToClient = "Here are all the users!",
                ResponseData = _userService.GetUsers()
            };
        }

        [HttpGet]
        public ResponseDto GetUserById([FromRoute] int id)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the wanted user with id = " + id,
                ResponseData = _userService.GetUserById(id)
            };
        }
        
        [HttpPost]
        public ResponseDto CreateUser([FromBody] User user)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the created user: " + user,
                ResponseData = _userService.CreateUser(user)
            };
        }

        [HttpPut]
        public ResponseDto UpdateUser([FromRoute] int id,[FromBody]User user)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the updated user: " + user,
                ResponseData = _userService.UpdateUser(id ,user)
            };
        }

        [HttpDelete]
        public ResponseDto DeleteUser([FromRoute] int id)
        {   
            _userService.DeleteUser(id);
            
            return new ResponseDto()
            {
            MessageToClient = "You deleted the user with id = " + id + " succssefully!"
            };
        }
        
    }
}