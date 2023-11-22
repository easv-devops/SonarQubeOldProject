using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.TransferModels;
using api.TransferModels.AvatarImageDto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace api.Controllers
{
    public class AvatarImageController : BaseApiController
    {
        private readonly AvatarImageService _service;

        public AvatarImageController(AvatarImageService service)
        {
            _service = service;
        }

        [HttpGet]
        public ResponseDto GetAllAvatarImages()
        {
            return new ResponseDto()
            {
                MessageToClient = "Here are all the Avatar Images.",
                ResponseData = _service.GetAll()
            };
        }
        [HttpGet("{id}")]
        public ResponseDto GetAvatarImageById([FromRoute] int id)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the wanted Avatar Image with id: " + id,
                ResponseData = _service.GetById(id)
            };
        }
        [HttpPost]
        public ResponseDto CreateAvatarImage([FromBody] CreateAvatarImageDto avatarImageDto)
        {
            return new ResponseDto()
            {
                MessageToClient = "Avatar Image was created successfully!",
                ResponseData = _service.Create(avatarImageDto.UserId, avatarImageDto.PictureUrl)
            };
        }
        [HttpPut("{id}")]
        public ResponseDto UpdateAvatarImage([FromRoute] int id, [FromBody] CreateAvatarImageDto avatarImageDto)
        {
            return new ResponseDto()
            {
                MessageToClient = "Avatar Image was updated successfully!",
                ResponseData = _service.Update(id, avatarImageDto.UserId, avatarImageDto.PictureUrl)
            };
        }
        [HttpDelete("{id}")]
        public ResponseDto DeleteAvatarImage([FromRoute] int id)
        {
            _service.Delete(id);
            
            return new ResponseDto()
            {
                MessageToClient = "The Avatar Image with id: " + id + " deleted successfully!",
                ResponseData = null
            };
        }
    }

}