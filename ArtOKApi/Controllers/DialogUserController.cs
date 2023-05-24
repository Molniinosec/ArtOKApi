using ArtOKApi.Interfaces;
using ArtOKApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtOKApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialogUserController : Controller
    {
        private readonly IDialogUserInterface _comment;

        public DialogUserController(IDialogUserInterface post)
        {
            _comment = post;
        }

        [HttpGet("AllDialogs")]
        public IActionResult GetDialogs()
        {
            var comments = _comment.GetDialogs();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(comments);
        }

        [HttpGet("{IDUser}")]
        public IActionResult GetUserDialogs(int IDUser)
        {
            var comments = _comment.GetUserDialogs(IDUser);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(comments);
        }
        [HttpGet("AllDialogs-{IDUser}")]
        public IActionResult GetAllDialogUsers(int IDUser)
        {
            var comments = _comment.GetAllDialogUsers(IDUser);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(comments);
        }
        [HttpGet("Messages-{IDDialog}")]
        public IActionResult GetDialogMessages(int IDDialog)
        {
            var comments = _comment.GetDialogMessages(IDDialog);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(comments);
        }
        [HttpPost("MessageAdd")]
        public IActionResult AddMessage([FromBody]Messages message)
        {
            if (message == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_comment.AddMessage(message))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }
        [HttpPost("CreateDialog")]
        public IActionResult CreateDialog([FromBody]Dialog dialog)
        {
            if (dialog == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_comment.CreateDialog(dialog))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }
        [HttpPost("AddUserInDialog")]
        public IActionResult AddUserInDialog([FromBody] DialogUser DialogUser)
        {
            if (DialogUser == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_comment.AddUserInDialog(DialogUser))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfuly created");
        }
    }
}
