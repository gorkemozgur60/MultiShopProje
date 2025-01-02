using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MutliShop.Comment.Context;
using MutliShop.Comment.Entites;

namespace MutliShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentContext.UserComments.ToList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(string id)
        {
            var value = _commentContext.UserComments.Find(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateComment(UserComment createComment)
        {
            _commentContext.UserComments.Add(createComment);
            _commentContext.SaveChanges();
            return Ok("Yorum başarıyla eklendi");
        }
        [HttpPut]
        public IActionResult UpdateComment(UserComment updateComment)
        {
            _commentContext.UserComments.Update(updateComment);
            _commentContext.SaveChanges();
            return Ok("Yorum başarıyla güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _commentContext.UserComments.Find(id);
            _commentContext.UserComments.Remove(value);
            _commentContext.SaveChanges();
            return Ok("Yorum başarıyla silindi");
        }

        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var value = _commentContext.UserComments.Where(x => x.ProductId == id).ToList();
            return Ok(value);
        }

        [HttpGet("GetActiveCommentCount")]
        public IActionResult GetActiveCommentCount()
        {
            var values = _commentContext.UserComments.Where(x => x.status == true).Count();
            return Ok(values);
        }

        [HttpGet("GetPassiveCommentCount")]
        public IActionResult GetPassiveCommentCount()
        {
            var values = _commentContext.UserComments.Where(x => x.status == false).Count();
            return Ok(values);
        }

        [HttpGet("GetTotalCommentCount")]
        public IActionResult GetTotalCommentCount()
        {
            var values = _commentContext.UserComments.Count();
            return Ok(values);
        }


    }
}
