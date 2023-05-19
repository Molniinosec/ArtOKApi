using ArtOKApi.Data;
using ArtOKApi.Interfaces;
using ArtOKApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;



namespace ArtOKApi.Repository
{
    public class ImageRepository : IImageInterface
    {
        private readonly DataContext _context;

        public ImageRepository(DataContext context)
        {
            _context = context;
        }

        //public string CreateFilePicture([FromForm]Post file)
        //{
        //    string path = Path.Combine(@"C:\\Users\\izran\\source\\repos\\ArtOKApi\\ArtOKApi\\wwwroot\\Uploads",
        //                               (Convert.ToString(DateTime.Now.Ticks)) + file.Ifile.FileName);
        //    using (Stream stream = new FileStream(path, FileMode.Create))
        //    {
        //        file.Ifile.CopyTo(stream);
        //    }
        //    return path;
        //}


        public string CreateFilePicture(FilePic Ifile)
        {
            
            //string path = Path.Combine(@"C:\\Users\\izran\\source\\repos\\ArtOKApi\\ArtOKApi\\wwwroot\\Uploads",
                                     // (Convert.ToString(DateTime.Now.Ticks)));

            string path = Path.Combine(@"C:\Users\izran\source\repos\ArtOKApi\ArtOKApi\wwwroot\Uploads",
                                      (Convert.ToString(DateTime.Now.Ticks)));

            File.WriteAllBytes(path, Ifile.byteFile);

            //using (Stream stream = new FileStream(path, FileMode.Create))
            //{
            //    //filePic.Ifile.CopyTo(stream);
            //    File(filePic.byteFile, "image/jpeg");

            //}
            return path;
        }
        public bool createPicture(Picture picture)
        {
            _context.Add(picture);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        Picture IImageInterface.GetPicturePath(int IDPost)
        {
            return _context.Picture.Where(p=>p.PostID==IDPost).FirstOrDefault();
        }
    }
}
