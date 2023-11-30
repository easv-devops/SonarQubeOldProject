using api.TransferModels;
using api.TransferModels.UserDto;
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

        [HttpGet("{id}")]
        public ResponseDto GetUserById([FromRoute] int id)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the wanted user with id = " + id,
                ResponseData = _userService.GetUserById(id)
            };
        }
        
        [HttpPost]
        public ResponseDto CreateUser([FromBody] CreateUserDto dto)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the created user: " + dto,
                ResponseData = _userService.CreateUser(dto.Username, dto.Email, dto.Password, dto.ShortDescription)
            };
        }

        [HttpPut("{id}")]
        public ResponseDto UpdateUser([FromRoute] int id,[FromBody] UpdateUserDto dto)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the updated user: " + dto,
                ResponseData = _userService.UpdateUser(id, dto.Username, dto.Email, dto.Password, dto.ShortDescription) 
            };
        }

        [HttpDelete("{id}")]
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