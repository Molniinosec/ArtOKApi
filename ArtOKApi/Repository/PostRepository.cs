using ArtOKApi.Data;
using ArtOKApi.Interfaces;
using ArtOKApi.Models;

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



        public ICollection<Post> GetPosts()
        {
            return _context.Post.Where(p=>p.IsDeleted!=true).OrderByDescending(p => p.TimeOfCreate).ToList();
        }

        public ICollection<Post> GetUserPosts(int IDuser)
        {
            return _context.Post.Where(p => p.IDUser == IDuser && p.IsDeleted!=true).OrderByDescending(p =>p.TimeOfCreate).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved>0 ? true : false;
        }
    }
}
