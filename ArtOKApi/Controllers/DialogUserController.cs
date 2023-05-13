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
    }
}
