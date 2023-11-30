using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace api.TransferModels.CourseDto
{
    public class CreateCourseDto
    {
        [Required, NotNull]
        [MinLength (4), MaxLength(50)]
        public string? Name { get; set; }
        [Required, NotNull]
        [Description("experience_level")]
        public int ExperienceLevel { get; set; }
        [Required, NotNull]
        public string? Description { get; set; }
        [Required, NotNull]
        [Description("owner_id")]
        public int OwnerId { get; set; }
        
        public decimal Price { get; set; }
    }
}