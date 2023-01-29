namespace ArtOKApi.Models
{
    public class Dialog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public System.DateTime DateOfCreation { get; set; }
        public string DialogPicture { get; set; }

        public  ICollection<DialogUser> DialogUser { get; set; }
    }
}
