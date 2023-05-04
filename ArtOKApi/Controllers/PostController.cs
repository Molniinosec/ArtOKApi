using ArtOKApi.Dto;
using ArtOKApi.Interfaces;
using ArtOKApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtOKApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostInterface _postInterface;
        private readonly IMapper _mapper;

        public PostController(IPostInterface postInterface, IMapper mapper)
        {
            _postInterface = postInterface;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Post>))]
        public IActionResult GetPosts()
        {
            //var posts = _mapper.Map<List<PostDto>>(_postInterface.GetPosts());
            var posts = _postInterface.GetPosts();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(posts);
        }
        [HttpGet("{IDuser}")]
        [ProducesResponseType(201, Type = typeof(IEnumerable<Post>))]
        [ProducesResponseType(400)]
        public IActionResult GetUserPosts(int IDuser)
        {
            //var post = _mapper.Map<PostDto>(_postInterface.GetUserPosts(IDuser));
            var post = _postInterface.GetUserPosts(IDuser);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(post);
        }

        [HttpPost("CreatePost")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePost([FromBody] Post createPost)
        {
            if (createPost == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var postMap = _mapper.Map<Post>(createPost);
            var postMap = createPost;

            if (!_postInterface.CreatePost(postMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }
    }
}
