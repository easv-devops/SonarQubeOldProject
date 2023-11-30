using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace api.TransferModels.ResourcesDto
{
    public class UpdateResourceDto
    {
        [Required, NotNull]
        [MinLength(5), MaxLength(50)]
        public string? Name { get; set; }
        [Required, NotNull]
        [MinLength(5), MaxLength(50)]
        public string? Type { get; set; }
        [Required, NotNull]
        [MinLength(5)]
        public string? Link { get; set; }
        [Required, NotNull]
        [Description ("course_id")]
        public int CourseId { get; set; }
    }
}
