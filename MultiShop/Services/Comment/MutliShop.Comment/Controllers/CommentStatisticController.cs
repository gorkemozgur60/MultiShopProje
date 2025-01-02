using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MutliShop.Comment.Context;

namespace MutliShop.Comment.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentStatisticController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentStatisticController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalCommentCount()
        {
            var values = await _commentContext.UserComments.CountAsync();
            return Ok(values);
        }
    }
}
