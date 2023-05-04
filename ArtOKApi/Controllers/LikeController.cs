using ArtOKApi.Interfaces;
using ArtOKApi.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
