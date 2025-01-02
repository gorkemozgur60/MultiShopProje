using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Areas.Admin.Services.CommentServices;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.CommentServices.NoLoginCommentServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        private readonly INoLoginCommentService _commentService;

        public _ProductDetailReviewComponentPartial(INoLoginCommentService commentService)
        {
            _commentService = commentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _commentService.CommentListByProductId(id);

            if(values == null)
            {
                var newComment = new List<ResultCommentDto>
                {
                    new ResultCommentDto
                    {
                        CommentDetail = "",
                        CreatedTime = DateTime.UtcNow,
                        UserCommentId = 0,
                        Email = "",
                        ImageUrl = "",
                        Rating = 0,
                        NameSurname = "",
                        ProductId = "",
                        status = false
                    }
                };

                return View(newComment);
            }

            return View(values);
        }

    }
    
}
