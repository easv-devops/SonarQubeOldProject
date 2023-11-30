using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace api.TransferModels.CourseDto
{
    public class UpdateCourseDto
    {
        [Required, NotNull]
        [MinLength (4), MaxLength(50)]
        public string? Name { get; set; }
        [Required, NotNull]
        [Description("experience_level")]
        public int ExperienceLevel { get; set; }
        [Required, NotNull]
        [MinLength(10)]
        public string? Description { get; set; }
        [Required, NotNull]
        [Description("owner_id")]
        public int OwnerId { get; set; }
        public decimal Price { get; set; }
    }
}