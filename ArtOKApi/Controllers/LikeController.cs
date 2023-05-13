using ArtOKApi.Interfaces;
using ArtOKApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;

namespace ArtOKApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : Controller
    {
        private readonly ILikeInterface _likeInterface;

        public LikeController(ILikeInterface likeInterface)
        {
            _likeInterface = likeInterface;
        }
        [HttpGet("{IDPost}")]
        [ProducesResponseType(200, Type = typeof(int))]
        public IActionResult GetPostLike(int IDPost)
        {
            var followers = _likeInterface.GetPostLikes(IDPost);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(followers);
        }
        [HttpGet]
        public IActionResult GetLikes()
        {
            var followers = _likeInterface.GetAllLikes();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(followers);
        }
        [HttpGet("User-{IDUser}")]
        public IActionResult GetUserLikes(int IDUser)
        {
            var followers = _likeInterface.GetUserLikes(IDUser);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(followers);
        }
        [HttpPost("AddLike")]
        public IActionResult AddLike([FromBody] Like like)
        {
            if (like == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_likeInterface.AddLike(like))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }
        [HttpDelete("DeleteLike-{IDLike}")]
        public IActionResult DeleteLike(int IDLike)
        {
            if (IDLike == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var delLike = _likeInterface.GetLikeByID(IDLike);

            if (!_likeInterface.RemoveLike(delLike))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly deleted");
        }
    }
}
