using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace api.TransferModels.CourseDto
{
    public class CreateCourseDto
    {
        public string Name { get; set; }
        [Description("experience_level")]
        public int ExperienceLevel { get; set; }
        public string Description { get; set; }
        [Description("owner_id")]
        public int OwnerId { get; set; }
        public decimal Price { get; set; }
    }
}