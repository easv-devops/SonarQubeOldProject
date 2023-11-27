using api.TransferModels;
using api.TransferModels.CourseDto;
using api.TransferModels.CourseEnrollDto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace api.Controllers
{
    public class CourseEnrollController : BaseApiController
    {
        private readonly CourseEnrollService _service;

        public CourseEnrollController(CourseEnrollService service)
        {
            _service = service;
        }

        [HttpGet]
        public ResponseDto GetAll()
        {
            return new ResponseDto()
            {
                MessageToClient = "Here are all the course enrolls!",
                ResponseData = _service.GetAll()
            };
        }
        [HttpGet("{id}")]
        public ResponseDto GetCourseEnrollById(int id)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the wanted course enroll!",
                ResponseData = _service.GetById(id)
            };
        }
        [HttpPost]
        public ResponseDto CreateCourseEnroll([FromBody] CreateCourseEnrollDto dto)
        {
            return new ResponseDto()
            {
                MessageToClient = "The course enroll was created succsefully!",
                ResponseData = _service.Create(dto.UserId, dto.CourseId)
            };
        }
        [HttpPut("{id}")]
        public ResponseDto UpdateCourseEnroll([FromRoute] int id, [FromBody] UpdateCourseEnrollDto dto)
        {
            return new ResponseDto()
            {
                MessageToClient = "The course enroll with id: " + id + " was updated succsefully!",
                ResponseData = _service.Update(id, dto.UserId, dto.CourseId)
            };
        }
        [HttpDelete("{id}")]
        public ResponseDto DeleteCourseEnroll([FromRoute] int id)
        {
            _service.Delete(id);
            
            return new ResponseDto()
            {
                MessageToClient = "The course enroll with id: " + id + " was deleted succsefully!",
                ResponseData = null
            };
        }
    }
}