using ArtOKApi.Data;
using ArtOKApi.Dto;
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

        public bool CreateUser(User user)
        {
            _context.Add(user);
            return Save();
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

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved>0 ? true : false;
        }

        public User UserEsists(string login, string password)
        {
            return _context.User.Where(u => u.NickName == login && u.Password== password).FirstOrDefault();
        }

        public bool UserExists(int id)
        {
            return _context.User.Any(u => u.ID == id);
        }


    }
}
