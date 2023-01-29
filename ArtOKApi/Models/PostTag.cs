using Azure;

namespace ArtOKApi.Models
{
    public class PostTag
    {
        public int ID { get; set; }
        public int IDPost { get; set; }
        public int IDTag { get; set; }

        public  Post Post { get; set; }
        public  Tag Tag { get; set; }
    }
}
