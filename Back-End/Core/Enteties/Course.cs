using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enteties
{
    public class Course : BaseEntity
    {
        [Required, MinLength(3), MaxLength(50)]

        public string Name { get; set; }   
        [Required, NotNull]
        [Description("experience_level")]
        public int ExpirienceLevel { get; set; }
        [Required, MinLength(50)]
        public CourseLevel CourseLevel { get; set; }
        public string Descrpition { get; set; }
        [Required, NotNull]
        [Description("owner_id")]
        public int OwnerId { get; set; }
        [Required, NotNull]
        public User Owner { get; set; }
        public decimal Price { get; set; }
        

    }
}