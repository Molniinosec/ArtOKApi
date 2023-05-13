using ArtOKApi.Data;
using ArtOKApi.Interfaces;
using ArtOKApi.Models;

namespace ArtOKApi.Repository
{
    public class DialogUserRepository : IDialogUserInterface
    {
        private readonly DataContext _context;

        public DialogUserRepository(DataContext context)
        {
            _context = context;
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
    }
}
