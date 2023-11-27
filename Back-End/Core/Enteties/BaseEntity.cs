using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Core.Enteties
{
    public class BaseEntity
    {
        [Required, NotNull]

        public int Id { get; set; }
    }
}