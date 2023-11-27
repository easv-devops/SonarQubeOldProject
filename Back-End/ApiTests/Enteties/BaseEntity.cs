using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTests.Enteties
{
    public class BaseEntity
    {
        [Required, NotNull]
        public  int  Id { get; set; }
    }
}