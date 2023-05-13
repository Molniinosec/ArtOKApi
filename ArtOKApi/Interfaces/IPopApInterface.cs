using ArtOKApi.Models;

namespace ArtOKApi.Interfaces
{
    public interface IPopApInterface
    {
        ICollection<PopApp> GetPopApps();
        ICollection<PopApp> GetPostPopApps(int IDPost);
        int PopAppCount(int IDPost);

    }
}
