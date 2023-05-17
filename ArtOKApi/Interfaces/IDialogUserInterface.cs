using ArtOKApi.Models;
using Microsoft.AspNetCore.Components.Web;

namespace ArtOKApi.Interfaces
{
    public interface IDialogUserInterface
    {
        ICollection<DialogUser> GetAllDialogUsers(int IDdialog);
        ICollection<Messages> GetDialogMessages(int IDDialog);
        ICollection<Dialog> GetUserDialogs(int IdUser);
        bool Save();
        bool AddMessage(Messages message);
    }
}
