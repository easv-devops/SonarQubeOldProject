using System.ComponentModel;

namespace api.TransferModels.CourseEnrollDto
{
    public class UpdateCourseEnrollDto
    {
        [Description ("user_id")]
        public int UserId { get; set; }
        [Description("course_id")]
        public int CourseId { get; set; }
    }
}