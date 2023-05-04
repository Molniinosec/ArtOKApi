using ArtOKApi.Data;
using ArtOKApi.Interfaces;
using ArtOKApi.Models;

namespace ArtOKApi.Repository
{
    public class LikeRepository : ILikeInterface
    {
        private readonly DataContext _context;

        public LikeRepository(DataContext context)
        {
            _context = context;
        }

        public int GetPostLikes(int IDPost)
        {
            return _context.Like.Count(l => l.IDPost == IDPost);
        }
    }
}
