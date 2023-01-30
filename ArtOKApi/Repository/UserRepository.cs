using ArtOKApi.Data;
using ArtOKApi.Interfaces;
using ArtOKApi.Models;

namespace ArtOKApi.Repository
{
    public class UserRepository : IUserInterface
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public int GetUserFollowers(int id)
        {
            var userFollowers = _context.Follower.Where(f => f.IDFollowedUser == id);
            if (userFollowers.Count() <= 0)
                return 0;

            return userFollowers.Count();
        }

        public ICollection<User> GetUsers()
        {
            return _context.User.OrderBy(u=>u.ID).ToList();
        }

        public User GetUsers(int id)
        {
            return _context.User.Where(u => u.ID == id).FirstOrDefault();
        }

        public User GetUsers(string name)
        {
            return _context.User.Where(u => u.NickName == name).FirstOrDefault();
        }

        public bool UserExists(int id)
        {
            return _context.User.Any(u => u.ID == id);
        }
    }
}
