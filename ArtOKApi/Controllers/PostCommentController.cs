using ArtOKApi.Interfaces;
using ArtOKApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtOKApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCommentController : Controller
    {
        private readonly IPostComment _comment;


        public PostCommentController(IPostComment post)
        {
            _comment = post;
        }

        [HttpGet("{IDPost}")]
        public IActionResult GetPostComments(int IDPost)
        {
            var comments = _comment.GetPostComments(IDPost);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(comments);
        }
        [HttpGet("comment-{IDPost}")]
        public IActionResult GetCommentCount(int IDPost)
        {
            var comments = _comment.CommentsCount(IDPost);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(comments);
        }
        [HttpPost("CreateComment")]
        public IActionResult CreateComment([FromBody]PostComment postComment)
        {
            if (postComment == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_comment.AddComment(postComment))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }
    }
}
