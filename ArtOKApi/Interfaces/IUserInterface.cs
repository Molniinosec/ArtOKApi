using ArtOKApi.Models;

namespace ArtOKApi.Interfaces
{
    public interface IUserInterface
    {
        ICollection<User> GetUsers();
    }
}
