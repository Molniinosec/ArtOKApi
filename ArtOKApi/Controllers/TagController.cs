using ArtOKApi.Interfaces;
using ArtOKApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;


namespace ArtOKApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : Controller
    {
        private readonly ITagInterface _tagInterface;

        public TagController(ITagInterface tagInterface)
        {
            _tagInterface = tagInterface;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Tag>))]
        public IActionResult GetTags()
        {
            var tags = _tagInterface.GetTags();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tags);
        }
        [HttpGet("followers{IDPost}")]
        public IActionResult GetPostTags(int IDPost)
        {
            var tags = _tagInterface.GetPostTags(IDPost);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tags);
        }
        [HttpGet("TagCount-{IDPost}")]
        public IActionResult GetTagCount(int IDPost)
        {
            var tags = _tagInterface.GetTagCount(IDPost);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tags);
        }
        [HttpPost("PostTagSave")]
        public IActionResult AddPostTag([FromBody]PostTag postTag)
        {
            if (postTag == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_tagInterface.AddTagPost(postTag))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }
    }
}
