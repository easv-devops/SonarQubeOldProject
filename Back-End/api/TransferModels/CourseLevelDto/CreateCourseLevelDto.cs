using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using api.CustomDataAnnotations;

namespace api.TransferModels.CourseLevelDto
{
    public class CreateCourseLevelDto
    {
        [Required, NotNull]
        [ValueIsOneOf(new string[] {"Beginner", "Intermediate", "Advanced", "Professional"},
                        "The value of the Course Level should be one of the following: Beginner, Intermediate, Advanced or Professional!") ]
        public string? Level { get; set; }
    }
}