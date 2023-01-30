using ArtOKApi.Models;

namespace ArtOKApi.Interfaces
{
    public interface IUserInterface
    {
        ICollection<User> GetUsers();
        User GetUsers(int id);
        User GetUsers(string name);
        int GetUserFollowers(int id);
        bool UserExists(int id);
    }
}
