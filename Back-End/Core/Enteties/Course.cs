using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Core.Enteties
{
    public class Course : BaseEntity
    {
        [Required, MinLength(3), MaxLength(50)]

        public string? Name { get; set; }   
        [Required, NotNull]
        [Description("experience_level")]
        public int ExperienceLevel { get; set; }
        public CourseLevel? CourseLevel { get; set; }
        public string? Description { get; set; }
        [Required, NotNull]
        [Description("owner_id")]
        public int OwnerId { get; set; }
        [Required, NotNull]
        public User? Owner { get; set; }
        public decimal Price { get; set; }
        

    }
}