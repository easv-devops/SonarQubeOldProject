using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.CustomDataAnnotations
{
    public class ValueIsOneOf : ValidationAttribute
    {
        private readonly string[] _validStrings;
        private readonly string? _errorMessage;

        public ValueIsOneOf(string[] validStrings, string? errorMessage = "")
        {
            _validStrings = validStrings;
            _errorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object? givenString, ValidationContext validationContext)
        {
            if (!_validStrings.Contains(givenString))
            {
                return new ValidationResult(_errorMessage);
            }

            return ValidationResult.Success!;
        }
    }
}