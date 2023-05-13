using ArtOKApi.Models;

namespace ArtOKApi.Interfaces
{
    public interface ILikeInterface
    {
        int GetPostLikes(int IDPost);
        ICollection<Like> GetAllLikes();
        ICollection<Like> GetUserLikes(int IDUser);
        Like GetLikeByID(int IDLike);
        bool RemoveLike(Like like);
        bool AddLike(Like like);
        bool Save();
    }
}
