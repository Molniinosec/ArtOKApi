using Azure;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtOKApi.Models
{
    public class PostTag
    {
        [NotMapped]
        public int ID { get; set; }
        public int IDPost { get; set; }
        public int IDTag { get; set; }

        public  Post? Post { get; set; }
        public  Tag? Tag { get; set; }
    }
}
