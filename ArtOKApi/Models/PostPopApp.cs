namespace ArtOKApi.Models
{
    public class PostPopApp
    {
        public int ID { get; set; }
        public int IDPost { get; set; }
        public int IDPopApp { get; set; }

        public  PopApp PopApp { get; set; }
        public  Post Post { get; set; }
    }
}
