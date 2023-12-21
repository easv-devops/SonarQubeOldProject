using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace api.TransferModels.AuthenticateDto
{
    public class LoginDto
    {
        [Required, NotNull]
        public string? Username { get; set; }
        [Required, NotNull]
        public string? Password { get; set; }
    }
}