using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.WireProtocol.Messages;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Areas.Admin.Services.CommentServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        public readonly IHttpClientFactory _httpClientFactory;
        private readonly IAdminCommentService _adminCommentService;

        public CommentController(IHttpClientFactory httpClientFactory, IAdminCommentService adminCommentService)
        {
            _httpClientFactory = httpClientFactory;
            _adminCommentService = adminCommentService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorum";
            ViewBag.v3 = "Yorum Listesi";
            ViewBag.v0 = "Yorum İşlemleri";

            var values = await _adminCommentService.GetAllCommentAsync();

            if (values == null)
            {
                return RedirectToAction("Index", "AdminLoginPanel", new { area = "Admin" });
            }

            return View(values);
        }

        [HttpGet]
        [Route("CreateComment")]
        public async Task<IActionResult> CreateComment()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorum";
            ViewBag.v3 = "Yorumler Listesi";
            ViewBag.v0 = "Yorumler Ekleme İşlemleri";


            var values = await _adminCommentService.GetAllCommentAsync();
            return View(values);
        }

        [HttpPost]
        [Route("CreateComment")]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            var values = await _adminCommentService.CreateCommentAsync(createCommentDto);

            if (values.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.DeleteAsync("https://localhost:7074/api/Comments?id=" + id);

            var values = await _adminCommentService.DeleteCommentAsync(id);

            if (values.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorum";
            ViewBag.v3 = "Yorumler Güncelleme Sayfası";
            ViewBag.v0 = "Yorumler İşlemleri";

            var values = await _adminCommentService.GetByIdCommentAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            //updateCommentDto.status = true;
            //var client = _httpClientFactory.CreateClient();
            //var JsonData = JsonConvert.SerializeObject(updateCommentDto);
            //StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PutAsync("https://localhost:7074/api/Comments/", stringContent);

            var values = await _adminCommentService.UpdateCommentAsync(updateCommentDto);

            if (values.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }
    }
}
