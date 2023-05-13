using ArtOKApi.Data;
using ArtOKApi.Interfaces;
using ArtOKApi.Models;

namespace ArtOKApi.Repository
{
    public class PostCommentRepository : IPostComment
    {
        private readonly DataContext _context;

        public PostCommentRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddComment(PostComment postComment)
        {
            _context.Add(postComment);
            return Save();
        }

        public int CommentsCount(int IDPost)
        {
            return _context.PostComment.Count(p => p.IDPost == IDPost);
        }

        public ICollection<PostComment> GetPostComments(int IDPost)
        {
            return _context.PostComment.Where(p => p.IDPost == IDPost).OrderByDescending(p => p.TimeOfWrite).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
