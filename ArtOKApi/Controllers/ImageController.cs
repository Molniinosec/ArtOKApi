using ArtOKApi.Interfaces;
using ArtOKApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;


namespace ArtOKApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        private readonly IImageInterface _imageInterface;

        public ImageController(IImageInterface imageInterface)
        {
            _imageInterface = imageInterface;
        }

        [HttpGet("{IDPost}")]
        public IActionResult GetPicture(int IDPost)
        {
            var picture = _imageInterface.GetPicturePath(IDPost);
            if (picture != null)
            {
                Byte[] b = null;
                if (picture.PicturePath!="" && picture.PicturePath != null)
                {
                    b = System.IO.File.ReadAllBytes(picture.PicturePath);   // You can use your own method over here.         
                    return File(b, "image/jpeg");

                }

            }
            return null;
        }
        //[HttpPost("PicturePath")]
        //public IActionResult SavePictureFile([FromForm] Post post)
        //{
        //    //string path = Path.Combine("C:\\Users\\izran\\source\\repos\\ArtOKApi\\ArtOKApi\\wwwroot\\Uploads", Convert.ToString(DateTime.Now));
        //    //using (Stream stream = new FileStream(path, FileMode.Create))
        //    //{
        //    //    file.Ifile.CopyTo(stream);
        //    //}
        //    string path = _imageInterface.CreateFilePicture(post);
        //    Picture picture = new Picture();
        //    picture.PicturePath = path;
        //    picture.PostID = post.ID;

        //    if (!_imageInterface.createPicture(picture))
        //    {
        //        ModelState.AddModelError("", "Something went wrong while saving");
        //        return StatusCode(500, ModelState);
        //    }
        //    return Ok("Succesfuly created");
        //}

        [HttpPost("PicturePath")]
        public IActionResult SavePictureFile([FromBody] FilePic filePic)
        {
            
            string path = _imageInterface.CreateFilePicture( filePic);
            //string path = Path.Combine(@"C:\\Users\\izran\\source\\repos\\ArtOKApi\\ArtOKApi\\wwwroot\\Uploads",
            //                          (Convert.ToString(DateTime.Now.Ticks)));
            ////+ filePic.Ifile.FileName);

            

            //using (Stream stream = new FileStream(path, FileMode.Create))
            //{
            //    //filePic.Ifile.CopyTo(stream);
            //    File(filePic.byteFile, "image/jpeg");
            //}
            Picture picture = new Picture();
            picture.PicturePath = path;
            picture.PostID =filePic.ID;

            if (!_imageInterface.createPicture(picture))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");

        }
    }
}
