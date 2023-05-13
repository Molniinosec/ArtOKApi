
using ArtOKApi.Data;
using ArtOKApi.Interfaces;
using ArtOKApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtOKApi.Repository
{
    public class TagRepository : ITagInterface
    {
        private readonly DataContext _dataContext;

        public TagRepository(DataContext dataContext)
        {
            _dataContext = dataContext; 
        }

        public bool AddTagPost(PostTag postTag)
        {
            _dataContext.Add(postTag);
            return Save();
        }

        public ICollection<Tag> GetPostTags(int IDPost)
        {
            return _dataContext.PostTag.Where(pt => pt.IDPost == IDPost).Select(t => t.Tag).ToList();
        }

        public int GetTagCount(int IDPost)
        {
            return _dataContext.PostTag.Count(pt => pt.IDPost == IDPost);
        }

        public ICollection<Tag> GetTags()
        {
            return _dataContext.Tag.OrderBy(t => t.ID).ToList();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
