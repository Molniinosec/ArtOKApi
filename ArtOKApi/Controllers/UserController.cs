using ArtOKApi.Dto;
using ArtOKApi.Interfaces;
using ArtOKApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ArtOKApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserInterface _userInterface;
        private readonly IMapper _mapper;

        public UserController(IUserInterface userInterface, IMapper mapper)
        {
            _userInterface = userInterface;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
           //var users = _mapper.Map<List<UserDto>>(_userInterface.GetUsers());
            var users = _userInterface.GetUsers();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }

        [HttpGet("{UserID}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int UserID)
        {
            if (!_userInterface.UserExists(UserID))
                return NotFound();

            //var users = _mapper.Map<UserDto>(_userInterface.GetUsers(UserID));
            var users = _userInterface.GetUser(UserID);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }
        [HttpGet("UserExist")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult UserExist(string login, string password)
        {
            var users = _userInterface.UserEsists(login, password);
            if (users is null)
                return NotFound();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }
        [HttpGet("{UserID}/ProfilePicture")]
        public IActionResult GetUserProfilePicture(int UserID)
        {
            var picture = _userInterface.GetUser(UserID);
            if (picture != null)
            {
                Byte[] b = null;
                if (picture.ProfilePicture != "" && picture.ProfilePicture != null)
                {
                    b = System.IO.File.ReadAllBytes(picture.ProfilePicture);   // You can use your own method over here.         
                    return File(b, "image/jpeg");

                }
            }
            return null;
        }
        [HttpGet("{UserID}/ProfileBackGround")]
        public IActionResult GetProfileBackground(int UserID)
        {
            var picture = _userInterface.GetUser(UserID);
            if (picture != null)
            {
                Byte[] b = null;
                if (picture.BackgroundPicture != "" && picture.BackgroundPicture != null)
                {
                    b = System.IO.File.ReadAllBytes(picture.BackgroundPicture);   // You can use your own method over here.         
                    return File(b, "image/jpeg");

                }
            }
            return null;
        }

        [HttpGet("{UserID}/followers")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public IActionResult GetUserFollowers(int UserID)
        {
            if (!_userInterface.UserExists(UserID))
                return NotFound();

            var user = _userInterface.GetUserFollowers(UserID);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] User createUser)
        {
            if (createUser == null)
                return BadRequest(ModelState);

            var user = _userInterface.GetUsers().Where(u => u.NickName == createUser.NickName || 
            u.Email == createUser.Email).FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", "User already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           //var userMap = _mapper.Map<User>(createUser);
            var userMap = createUser;

            if (!_userInterface.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }
    }
}
