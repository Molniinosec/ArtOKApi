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

        public bool AddLike(Like like)
        {
            _context.Add(like);
            return Save();
        }

        public ICollection<Like> GetAllLikes()
        {
            return _context.Like.ToList();
        }

        public Like GetLikeByID(int IDLike)
        {
            return _context.Like.Where(l => l.ID == IDLike).FirstOrDefault();
        }

        public int GetPostLikes(int IDPost)
        {
            return _context.Like.Count(l => l.IDPost == IDPost);
        }

        public ICollection<Like> GetUserLikes(int IDUser)
        {
            return _context.Like.Where(l => l.IDUser == IDUser).ToList();
        }

        public bool RemoveLike(Like like)
        {
            _context.Remove(like);
            return Save();
        }

        public bool Save()
        {
            var saved =_context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
