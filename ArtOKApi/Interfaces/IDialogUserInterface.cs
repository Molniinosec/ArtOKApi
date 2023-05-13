using ArtOKApi.Models;

namespace ArtOKApi.Interfaces
{
    public interface IDialogUserInterface
    {
        ICollection<DialogUser> GetAllDialogUsers(int IDdialog);
        ICollection<Messages> GetDialogMessages(int IDDialog);
        ICollection<Dialog> GetUserDialogs(int IdUser);
    }
}
