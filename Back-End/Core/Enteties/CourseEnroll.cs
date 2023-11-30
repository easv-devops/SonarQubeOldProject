using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enteties
{
    public class CourseEnroll : BaseEntity
    {
        [Description ("user_id")]
        public int UserId { get; set; }
        public User? User { get; set; }
        [Description("course_id")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}