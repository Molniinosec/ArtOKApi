using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtOKApi.Models
{
    public class Picture
    {
        public int ID { get; set; }
        public string PicturePath { get; set; }
        public int PostID { get; set; }

        public  Post Post { get; set; }
        //[NotMapped]
        //public IFormFile? Ifile { get; set; }
    }
}
