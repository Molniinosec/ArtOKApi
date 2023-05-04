using ArtOKApi.Models;
using Microsoft.AspNetCore.Components.Web;

namespace ArtOKApi.Interfaces
{
    public interface IImageInterface
    {
        Picture GetPicturePath(int IDImage);
        //string CreateFilePicture(Post file);
        string CreateFilePicture(FilePic file);
        bool createPicture(Picture picture);
        bool Save();
    }
}
