using Microsoft.Extensions.Hosting;

namespace ArtOKApi.Models
{
    public class Like
    {
        public int ID { get; set; }
        public int IDPost { get; set; }
        public int IDUser { get; set; }
        public Nullable<System.DateTime> DateOfLike { get; set; }

        public  Post? Post { get; set; }
        public  User? User { get; set; }
    }
}
