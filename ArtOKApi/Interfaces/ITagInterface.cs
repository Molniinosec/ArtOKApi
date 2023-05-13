using ArtOKApi.Models;

namespace ArtOKApi.Interfaces
{
    public interface ITagInterface
    {
        ICollection<Tag> GetTags();
        int GetTagCount(int IDPost);
        ICollection<Tag> GetPostTags(int IDPost);
        bool AddTagPost(PostTag postTag);
        bool Save();
    }
}
