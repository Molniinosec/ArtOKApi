using ArtOKApi.Data;
using ArtOKApi.Interfaces;
using ArtOKApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtOKApi.Repository
{
    public class DialogUserRepository : IDialogUserInterface
    {
        private readonly DataContext _context;

        public DialogUserRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddMessage(Messages message)
        {
            _context.Add(message);
            return Save();
        }

        public ICollection<DialogUser> GetAllDialogUsers(int IDdialog)
        {
            return _context.DialogUser.Where(d => d.IDDialog == IDdialog).ToList();
        }

        public ICollection<Messages> GetDialogMessages(int IDDialog)
        {
            return _context.Message.Where(m => m.IDUserDialog == IDDialog).ToList();
        }

        public ICollection<Dialog> GetUserDialogs(int IDUser)
        {
            return _context.DialogUser.Where(d => d.IDUser == IDUser).Select(d => d.Dialog).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
