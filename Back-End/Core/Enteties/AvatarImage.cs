using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enteties
{
    public class AvatarImage : BaseEntity
    {
        public int UserId { get; set; }

        [Description ("picture_url")]
        public string PictureUrl { get; set; }
    }
}