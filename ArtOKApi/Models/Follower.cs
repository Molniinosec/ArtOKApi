using System.ComponentModel.DataAnnotations.Schema;

namespace ArtOKApi.Models
{
    public class Follower
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int IDCurrentUser { get; set; }
        public int IDFollowedUser { get; set; }
        public Nullable<System.DateTime> TimeOfFollowing { get; set; }
        public bool IsBlockListed { get; set; }
        public User? CUser { get; set; }
        public User? FUser { get; set; }

    }
}
