using ArtOKApi.Data;
using ArtOKApi.Interfaces;
using ArtOKApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtOKApi.Repository
{
    public class PopAppRepository : IPopApInterface
    {
        private readonly DataContext _context;

        public PopAppRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<PopApp> GetPopApps()
        {
            return _context.PopApp.OrderBy(p=>p.ID).ToList();
        }

        public ICollection<PopApp> GetPostPopApps(int IDPost)
        {
            return _context.PostPopApp.Where(p => p.IDPost == IDPost).Select(p => p.PopApp).ToList();
        }

        public int PopAppCount(int IDPost)
        {
            return _context.PostPopApp.Where(p => p.IDPost == IDPost).Select(p => p.PopApp).Count();
        }

        public bool Save()
        {
            var saved =_context.SaveChanges();
            return saved>0? true: false;
        }

        public bool SavePostPopApp(PostPopApp postPopApp)
        {
            _context.Add(postPopApp);
            return Save();
        }
    }
}
