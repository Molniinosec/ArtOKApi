using ArtOKApi.Models;

namespace ArtOKApi.Interfaces
{
    public interface IFollowerInterface 
    {
        ICollection<Follower> GetFollowers();
        ICollection<Follower> GetCurrentUserFollowers(int UserID);
        Follower GetFollowerByID(int id);
        int GetFollowersCount(int UserID);
        int GetFollowedCount(int UserID);
        bool AddFollower(Follower follower);
        bool RemoveFollower(Follower follower);
        bool Save();
    }
}
