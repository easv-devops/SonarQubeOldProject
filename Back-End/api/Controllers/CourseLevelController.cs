using api.TransferModels;
using api.TransferModels.CourseLevelDto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace api.Controllers
{
    public class CourseLevelController : BaseApiController
    {
        private readonly CourseLevelService _service;

        public CourseLevelController(CourseLevelService service)
        {
            _service = service;
        }

        [HttpGet]
        public ResponseDto GetAll()
        {
            return new ResponseDto()
            {
                MessageToClient = "Here are all the course levels!",
                ResponseData = _service.GetAll()
            };
        }
        [HttpGet("{id}")]
        public ResponseDto GetById([FromRoute] int id)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the wanted course level with id: " + id,
                ResponseData = _service.GetById(id)
            };
        }
        [HttpPost]
        public ResponseDto Create([FromBody] CreateCourseLevelDto dto)
        {
            return new ResponseDto()
            {
                MessageToClient = "The course level was created succsefully!",
                ResponseData = _service.Create(dto.Level)
            };
        }
        [HttpPut("{id}")]
        public ResponseDto Update([FromRoute] int id, [FromBody] UpdateCourseLevelDto dto)
        {
            return new ResponseDto()
            {
                MessageToClient = "The course level was updated succsefully!",
                ResponseData = _service.Update(id, dto.Level)
            };
        }
        [HttpDelete("{id}")]
        public ResponseDto Delete([FromRoute] int id)
        {
            _service.Deleete(id);
            return new ResponseDto()
            {
                MessageToClient = "The course with id: " + id + " was deleted succsefully",
                ResponseData = null
            };
        }
    }
}