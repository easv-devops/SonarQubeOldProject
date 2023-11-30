using api.TransferModels;
using api.TransferModels.ResourcesDto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace api.Controllers
{
    public class ResourceController : BaseApiController
    {
        private readonly ResourcesService _service;

        public ResourceController(ResourcesService service)
        {
            _service = service;
        }
        [HttpGet]
        public ResponseDto GetAll()
        {
            return new ResponseDto()
            {
                MessageToClient = "Here are all the resources!",
                ResponseData = _service.GetAll()
            };
        }
        [HttpGet("{id}")]
        public ResponseDto GetById([FromRoute] int id)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the wanted resource!",
                ResponseData = _service.GetById(id)
            };
        }
        [HttpPost]
        public ResponseDto Create([FromBody] CreateResourceDto dto)
        {
            return new ResponseDto()
            {
                MessageToClient = "The resources was created succsefully!",
                ResponseData = _service.Create(dto.Name, dto.Type, dto.Link, dto.CourseId)
            };
        }
        [HttpPut("{id}")]
        public ResponseDto Update([FromRoute] int id, [FromBody] UpdateResourceDto dto)
        {
            return new ResponseDto()
            {
                MessageToClient = "The resoucre was update succsefully!",
                ResponseData = _service.Update(id, dto.Name, dto.Type, dto.Link, dto.CourseId)
            };
        }
        [HttpDelete("{id}")]
        public ResponseDto Delete([FromRoute] int id)
        {
            _service.Delete(id);
            return new ResponseDto()
            {
                MessageToClient = "The resource with id: " + id + " was deleted succsefully!",
                ResponseData = null
            };
        }
        
    }
}