using api.TransferModels;
using Core.Enteties;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace api.Controllers
{

    public class CourseController : BaseApiController
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ResponseDto GetAllCourses()
        {
           return new ResponseDto()
           {
                MessageToClient = "Here are all the courses!",
                ResponseData = _courseService.GetAll()
           }; 
        }
        [HttpGet("{id}")]
        public ResponseDto GetCourseById([FromRoute] int id)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the requested course with id: " + id,
                ResponseData = _courseService.GetById(id)
            };
        }

        [HttpPost]
        public ResponseDto CreateCourse([FromBody] Course course)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the created course " + course,
                ResponseData = _courseService.Create(course)
            };
        }
        [HttpPut("{id}")]
        public ResponseDto UpdateCourse([FromRoute] int id, [FromBody] Course course)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the updated course " + course,
                ResponseData = _courseService.Update(id, course)
            };
        }
        [HttpDelete("{id}")]
        public ResponseDto DeleteCourse([FromRoute] int id)
        {
            _courseService.Delete(id);
            return new ResponseDto()
            {
                MessageToClient = "Here is the deleted course's id: " + id,
            };
        }
     }
}