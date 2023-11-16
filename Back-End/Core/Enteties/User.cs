namespace Core.Enteties
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ShortDescription { get; set; }
    }
}