using ArtOKApi.Models;

namespace ArtOKApi.Interfaces
{
    public interface IFollowerInterface 
    {
        ICollection<Follower> GetFollowers();
        ICollection<Follower> GetCurrentUserFollowers(int UserID);
        int GetFollowersCount(int UserID);
        int GetFollowedCount(int UserID);
    }
}
