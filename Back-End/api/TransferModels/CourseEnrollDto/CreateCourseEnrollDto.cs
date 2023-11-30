using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace api.TransferModels.CourseEnrollDto
{
    public class CreateCourseEnrollDto
    {
        [Required, NotNull]
        [Description ("user_id")]
        public int UserId { get; set; }
        [Required, NotNull]
        [Description("course_id")]
        public int CourseId { get; set; }
    }
}