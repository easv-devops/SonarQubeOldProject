using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace api.TransferModels.AuthenticateDto
{
    public class RegisterUserDto
    {
        [Required, NotNull]
        public string? Username { get; set; }
        [Required, NotNull]
        [MaxLength(50, ErrorMessage = @"The email addres is too long!")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address!")]
        public string? Email { get; set; }
        [Required, NotNull]
        [MinLength(8, ErrorMessage = @"Password must be at least 8 characters long!")]
        public string? Password { get; set; }
        public string? ShortDescription { get; set; }
    }
}