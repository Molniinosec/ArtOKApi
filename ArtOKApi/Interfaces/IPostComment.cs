using ArtOKApi.Models;

namespace ArtOKApi.Interfaces
{
    public interface IPostComment 
    {
        ICollection<PostComment> GetPostComments(int IDPost);
        int CommentsCount(int IDPost);
        bool AddComment(PostComment postComment);
        bool Save();
    }
}
