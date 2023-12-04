using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTests.Enteties
{
    public class Course : BaseEntity
    {
        

        public string? Name { get; set; }   
        public int ExperienceLevel { get; set; }
        public string? Description { get; set; }
        
        public int OwnerId { get; set; }
        
        public decimal Price { get; set; }
    }
}