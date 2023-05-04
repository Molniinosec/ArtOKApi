namespace ArtOKApi.Dto
{
    public class PostDto
    {
        public int ID { get; set; }
        public int IDUser { get; set; }
        public string? Description { get; set; }
        public System.DateTime TimeOfCreate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
