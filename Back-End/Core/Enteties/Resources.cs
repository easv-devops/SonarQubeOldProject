using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enteties
{
    public class Resources : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        [Description ("course_id")]
        public int CourseId { get; set; }

    }
}