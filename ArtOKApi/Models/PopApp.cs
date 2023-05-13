namespace ArtOKApi.Models
{
    public class PopApp
    {
        public int ID { get; set; }
        public string NamePopApp { get; set; }
        public byte[]? Logo { get; set; }

        public  ICollection<PostPopApp>? PostPopApp { get; set; }
    }
}
