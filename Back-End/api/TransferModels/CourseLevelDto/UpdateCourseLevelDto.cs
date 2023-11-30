using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace api.TransferModels.CourseLevelDto
{
    public class UpdateCourseLevelDto
    {
        [Required, NotNull]
        public string? Level { get; set; }
    }
}