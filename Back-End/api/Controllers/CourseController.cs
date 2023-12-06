using api.TransferModels;
using api.TransferModels.CourseDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace api.Controllers
{
    [Authorize("AuthorizedPolicy")]
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
        public ResponseDto CreateCourse([FromBody] CreateCourseDto course)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the created course " + course,
                ResponseData = _courseService.Create(course.Name, 
                course.ExperienceLevel, course.Description, course.OwnerId, course.Price)
            };
        }
        [HttpPut("{id}")]
        public ResponseDto UpdateCourse([FromRoute] int id, [FromBody] UpdateCourseDto course)
        {
            return new ResponseDto()
            {
                MessageToClient = "Here is the updated course " + course,
                ResponseData = _courseService.Update(id, course.Name, course.ExperienceLevel, 
                                                     course.Description, course.OwnerId, course.Price)
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