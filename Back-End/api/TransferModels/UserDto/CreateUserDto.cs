using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace api.TransferModels.UserDto
{
    public class CreateUserDto
    {
        [Required, NotNull]
        [MinLength(5), MaxLength(50)]
        public string? Username { get; set; }
        [Required, NotNull]
        [MinLength(10), MaxLength(50)]
        [EmailAddress(ErrorMessage = "Invalid eamil address!")]
        public string? Email { get; set; }
        [Required, NotNull]
        [MinLength(8), MaxLength(50)]
        public string? Password { get; set; }
        [Required, NotNull]
        [MinLength(10), MaxLength(100)]
        public string? ShortDescription { get; set; } 
    }
}