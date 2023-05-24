using ArtOKApi.Interfaces;
using ArtOKApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtOKApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : Controller
    {
        private readonly IFollowerInterface _followerInterface;


        public FollowerController(IFollowerInterface followerInterface)
        {
            _followerInterface = followerInterface;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Follower>))]
        public IActionResult GetFollowers() 
        {
            var followers = _followerInterface.GetFollowers();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(followers);
        }

        [HttpGet("{IDuser}")]
        [ProducesResponseType(201, Type = typeof(IEnumerable<Follower>))]
        [ProducesResponseType(400)]
        public IActionResult GetCurrentUserFollowers(int IDuser)
        {
            var followers = _followerInterface.GetCurrentUserFollowers(IDuser);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(followers);
        }
        [HttpGet("CountFollowers/{UserID}")]
        public IActionResult GetoFollowersCount(int UserID)
        {
            var followers = _followerInterface.GetFollowersCount(UserID);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(followers);
        }
        [HttpGet("CountFollowed/{UserID}")]
        public IActionResult GetoFollowedCount(int UserID)
        {
            var followers = _followerInterface.GetFollowersCount(UserID);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(followers);
        }
        [HttpPost("AddFollower")]
        public IActionResult AddFollower(Follower follower)
        {
            if (follower == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_followerInterface.AddFollower(follower))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }
        [HttpDelete("Delete-{IDFollower}")]
        public IActionResult DeleteFollower(int IDFollower)
        {
            if (IDFollower == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var DelFollower = _followerInterface.GetFollowerByID(IDFollower);

            if (!_followerInterface.RemoveFollower(DelFollower))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }
    }
}
