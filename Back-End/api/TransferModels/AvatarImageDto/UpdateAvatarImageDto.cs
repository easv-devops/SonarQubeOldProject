using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace api.TransferModels.AvatarImageDto
{
    public class UpdateAvatarImageDto
    {
        public int UserId { get; set; }

        [Description ("picture_url")]
        public string PictureUrl { get; set; }
    }
}