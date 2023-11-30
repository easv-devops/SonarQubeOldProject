using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace api.TransferModels.AvatarImageDto
{
    public class CreateAvatarImageDto
    {
        [Required, NotNull]
        public int UserId { get; set; }

        [Description ("picture_url")]
        [Required, NotNull]
        public string? PictureUrl { get; set; }
    }
}