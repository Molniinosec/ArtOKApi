namespace ArtOKApi.Models
{
    public class DialogUser
    {
        public int ID { get; set; }
        public int IDUser { get; set; }
        public int IDDialog { get; set; }

        public  Dialog Dialog { get; set; }
        public  User User { get; set; }
        public  ICollection<Message> Message { get; set; }
    }
}
