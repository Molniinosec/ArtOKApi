
using ArtOKApi.Data;
using ArtOKApi.Interfaces;
using ArtOKApi.Models;

namespace ArtOKApi.Repository
{
    public class TagRepository : ITagInterface
    {
        private readonly DataContext _dataContext;

        public TagRepository(DataContext dataContext)
        {
            _dataContext = dataContext; 
        }
        public ICollection<Tag> GetTags()
        {
            return _dataContext.Tag.OrderBy(t => t.ID).ToList();
        }
    }
}
