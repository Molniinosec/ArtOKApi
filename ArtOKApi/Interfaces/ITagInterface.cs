using ArtOKApi.Models;

namespace ArtOKApi.Interfaces
{
    public interface ITagInterface
    {
        ICollection<Tag> GetTags();
    }
}
