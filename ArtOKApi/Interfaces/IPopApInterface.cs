using ArtOKApi.Models;

namespace ArtOKApi.Interfaces
{
    public interface IPopApInterface
    {
        ICollection<PopApp> GetPopApps();
        ICollection<PopApp> GetPostPopApps(int IDPost);
        bool SavePostPopApp(PostPopApp postPopApp);
        bool Save();
        int PopAppCount(int IDPost);

    }
}
