using System.ComponentModel;

namespace api.TransferModels.AvatarImageDto
{
    public class CreateAvatarImageDto
    {
        public int UserId { get; set; }

        [Description ("picture_url")]
        public string PictureUrl { get; set; }
    }
}