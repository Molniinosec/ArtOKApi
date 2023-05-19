using ArtOKApi.Dto;
using ArtOKApi.Models;

namespace ArtOKApi.Interfaces
{
    public interface IUserInterface
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        int GetUserFollowers(int id);
        bool UserExists(int id);
        User UserEsists(string login, string password);
        bool UpdateUser(User user);
        bool CreateUser(User user);
        bool Save();
    }
}
