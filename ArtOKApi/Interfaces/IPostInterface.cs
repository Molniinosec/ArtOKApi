using ArtOKApi.Models;

namespace ArtOKApi.Interfaces
{
    public interface IPostInterface
    {
        ICollection<Post> GetPosts();
        ICollection<Post> GetUserPosts(int IDuser);
        ICollection<Repost> GetReposts();
        ICollection<Repost> GetUserReposts(int IDUser);
        ICollection<Repost> GetRepostInPost(int IDPost);
        Repost GetSingleRepost(int IDRepost);
        bool CreatePost(Post post);
        bool CreateRepost(Repost repost);
        bool DeleteRepost(Repost repost);
        bool Save();
        int RepostCount(int IDPost);
    }
}
