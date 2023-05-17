using ArtOKApi.Data;
using ArtOKApi.Interfaces;
using ArtOKApi.Models;
using Microsoft.Extensions.Hosting;

namespace ArtOKApi.Repository
{
    public class PostRepository : IPostInterface
    {
        private readonly DataContext _context;

        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreatePost(Post post)
        {
            _context.Add(post);
            return Save();
        }

        public bool CreateRepost(Repost repost)
        {
            _context.Add(repost);
            return Save();
        }

        public bool DeleteRepost(Repost repost)
        {
            _context.Remove(repost);
            return Save();
        }

        public ICollection<Post> GetPosts()
        {
            return _context.Post.Where(p=>p.IsDeleted!=true).OrderByDescending(p => p.TimeOfCreate).ToList();
        }

        public ICollection<Repost> GetRepostInPost(int IDPost)
        {
            return _context.Repost.Where(r => r.IDRepostedPost == IDPost).ToList();
        }

        public ICollection<Repost> GetReposts()
        {
            return _context.Repost.ToList();
        }

        public ICollection<Post> GetUserPosts(int IDuser)
        {
            return _context.Post.Where(p => p.IDUser == IDuser && p.IsDeleted!=true).OrderByDescending(p =>p.TimeOfCreate).ToList();
        }

        public ICollection<Repost> GetUserReposts(int IDUser)
        {
            return _context.Repost.Where(r => r.IDUser == IDUser).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved>0 ? true : false;
        }
        public Repost GetSingleRepost(int IDRepost)
        {
            return _context.Repost.Where(r => r.ID == IDRepost).FirstOrDefault();
        }

        public int RepostCount(int IDPost)
        {
            return _context.Repost.Count(r => r.IDRepostedPost == IDPost);
        }
    }
}
