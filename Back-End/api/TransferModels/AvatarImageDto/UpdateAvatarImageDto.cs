using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace api.TransferModels.AvatarImageDto
{
    public class UpdateAvatarImageDto
    {
        [Required, NotNull]
        public int UserId { get; set; }

        [Required, NotNull]
        [Description ("picture_url")]
        public string? PictureUrl { get; set; }
    }
}