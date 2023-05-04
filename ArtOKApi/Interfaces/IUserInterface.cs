using ArtOKApi.Dto;
using ArtOKApi.Models;

namespace ArtOKApi.Interfaces
{
    public interface IUserInterface
    {
        ICollection<User> GetUsers();
        User GetUsers(int id);
        int GetUserFollowers(int id);
        bool UserExists(int id);
        User UserEsists(string login, string password);
        bool CreateUser(User user);
        bool Save();
    }
}
