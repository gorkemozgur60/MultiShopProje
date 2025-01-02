using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Areas.Admin.Services.CommentServices;
using MultiShop.WebUI.Areas.Admin.Services.MessageServices;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.Interface;
using MultiShop.WebUI.Services.MessageServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayaoutHeaderComponentPartial : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;

        public _AdminLayaoutHeaderComponentPartial(IMessageService messageService, ICommentService commentService, IUserService userService)
        {
            _messageService = messageService;
            _commentService = commentService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            var messageCount = await _messageService.GetTotalMessageCountByReceiverId(user.Id);
            var commentCount = await _commentService.GetTotalCommentCount();

            ViewBag.MessageCount = messageCount;
            ViewBag.CommentCount = commentCount;
            return View();
        }
    }
}
