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

        public bool AddFollower(Follower follower)
        {
            _context.Add(follower);
            return Save();
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
            return _context.Follower.OrderByDescending(f => f.ID).ToList();
        }

        public int GetFollowersCount(int UserID)
        {
            return _context.Follower.Count(f => f.IDCurrentUser == UserID);
        }

        public bool RemoveFollower(Follower follower)
        {
            _context.Remove(follower);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >0? true: false;
        }
        public Follower GetFollowerByID(int id)
        {
            return _context.Follower.FirstOrDefault(f => f.ID == id);
        }
    }
}
