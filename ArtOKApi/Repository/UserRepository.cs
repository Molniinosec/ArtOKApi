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
        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(u=>u.ID).ToList();
        }
    }
}
