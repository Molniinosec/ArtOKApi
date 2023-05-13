using System.ComponentModel.DataAnnotations.Schema;

namespace ArtOKApi.Models
{
    public class Tag
    {
        public int ID { get; set; }
        public string? NameTag { get; set; }

        public  ICollection<PostTag>? PostTag { get; set; }
    }
}
