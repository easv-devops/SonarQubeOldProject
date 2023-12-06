using api.TransferModels;
using api.TransferModels.UserDto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace api.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly UserService _service;

        public UsersController (UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public ResponseDto GetAllUsers()
        {

            return new ResponseDto()
            {
                MessageToClient = "Here are all the users!",
                ResponseData = _service.GetUsers()
            };
        }

        [HttpGet("{id}")]
        public ResponseDto GetUserById([FromRoute] int id)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the wanted user with id = " + id,
                ResponseData = _service.GetUserById(id)
            };
        }
        
        [HttpPost]
        public ResponseDto CreateUser([FromBody] CreateUserDto dto)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the created user: " + dto,
                ResponseData = _service.CreateUser(dto.Username, dto.Email, dto.Password, dto.ShortDescription)
            };
        }

        [HttpPut("{id}")]
        public ResponseDto UpdateUser([FromRoute] int id,[FromBody] UpdateUserDto dto)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the updated user: " + dto,
                ResponseData = _service.UpdateUser(id, dto.Username, dto.Email, dto.Password, dto.ShortDescription) 
            };
        }

        [HttpDelete("{id}")]
        public ResponseDto DeleteUser([FromRoute] int id)
        {   
            _service.DeleteUser(id);
            
            return new ResponseDto()
            {
            MessageToClient = "You deleted the user with id = " + id + " succssefully!"
            };
        }
        
    }
}