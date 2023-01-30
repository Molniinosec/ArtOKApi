namespace ArtOKApi.Dto
{
    public class UserDto
    {
        public int ID { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ProfilePicture { get; set; }
        public string? BackgroundPicture { get; set; }
        public System.DateTime TimeOfRegistration { get; set; }
        public System.DateTime Birthday { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
