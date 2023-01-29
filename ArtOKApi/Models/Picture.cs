using Microsoft.Extensions.Hosting;

namespace ArtOKApi.Models
{
    public class Picture
    {
        public int ID { get; set; }
        public string PicturePath { get; set; }
        public int PostID { get; set; }

        public  Post Post { get; set; }
    }
}
