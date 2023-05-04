using ArtOKApi.Models;

namespace ArtOKApi.Interfaces
{
    public interface IPostInterface
    {
        ICollection<Post> GetPosts();
        ICollection<Post> GetUserPosts(int IDuser);
        bool CreatePost(Post post);
        bool Save();
    }
}
