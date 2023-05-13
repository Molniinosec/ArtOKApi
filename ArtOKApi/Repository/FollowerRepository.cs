using ArtOKApi.Data;
using ArtOKApi.Interfaces;
using ArtOKApi.Models;
using AutoMapper;

namespace ArtOKApi.Repository
{
    public class FollowerRepository : IFollowerInterface
    {
        private readonly DataContext _context;

        public FollowerRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Follower> GetCurrentUserFollowers(int UserID)
        {
            return _context.Follower.Where(f => f.IDCurrentUser == UserID).ToList();
        }

        public int GetFollowedCount(int UserID)
        {
            return _context.Follower.Count(f => f.IDFollowedUser == UserID);
        }

        public ICollection<Follower> GetFollowers()
        {
            return _context.Follower.OrderBy(f => f.ID).ToList();
        }

        public int GetFollowersCount(int UserID)
        {
            return _context.Follower.Count(f => f.IDCurrentUser == UserID);
        }
    }
}
