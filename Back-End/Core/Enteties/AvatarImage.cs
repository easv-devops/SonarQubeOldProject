using System.ComponentModel;

namespace Core.Enteties
{
    public class AvatarImage : BaseEntity
    {
        [Description("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Description ("picture_url")]
        public string PictureUrl { get; set; }
    }
}