namespace ArtOKApi.Models
{
    public class Post
    {
        public int ID { get; set; }
        public int IDUser { get; set; }
        public string Description { get; set; }
        public System.DateTime TimeOfCreate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

        public  ICollection<Like> Like { get; set; }
        public  ICollection<Picture> Picture { get; set; }
        public  ICollection<PostTag> PostTag { get; set; }
        public  User User { get; set; }
        public  ICollection<PostComment> PostComment { get; set; }
        public  ICollection<PostPopApp> PostPopApp { get; set; }
        public  ICollection<Repost> Repost { get; set; }
    }
}
