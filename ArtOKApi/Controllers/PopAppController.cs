using ArtOKApi.Interfaces;
using ArtOKApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtOKApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopAppController : Controller
    {
        private readonly IPopApInterface _comment;


        public PopAppController(IPopApInterface post)
        {
            _comment = post;
        }

        [HttpGet]
        public IActionResult GetPopApps()
        {
            var comments = _comment.GetPopApps();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(comments);
        }
        [HttpGet("{IDPost}")]
        public IActionResult GetPostPopApp(int IDPost)
        {
            var comments = _comment.GetPostPopApps(IDPost);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(comments);
        }
        [HttpGet("PopApps-{IDPost}")]
        public IActionResult GetPopAppCount(int IDPost)
        {
            var comments = _comment.PopAppCount(IDPost);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(comments);
        }
        [HttpPost("AddPopApp")]
        public IActionResult AddPostPopApp(PostPopApp postPopApp)
        {
            if (postPopApp == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!_comment.SavePostPopApp(postPopApp))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }
    }
}
