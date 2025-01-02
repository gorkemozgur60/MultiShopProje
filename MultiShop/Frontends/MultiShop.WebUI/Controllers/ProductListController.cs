using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICommentService _commentService;
        public ProductListController(IHttpClientFactory httpClientFactory, ICommentService commentService)
        {
            _httpClientFactory = httpClientFactory;
            _commentService = commentService;
        }

        public IActionResult Index(string id)
        {
            ViewBag.directory1 = "Anasayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Ürün Listesi";
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.directory1 = "Anasayfa";
            ViewBag.directory2 = "Ürün Listesi";
            ViewBag.directory3 = "Ürün Detayları";
            
            ViewBag.x = id;
            return View(); 
        }

        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.ImageUrl = "/test";
            createCommentDto.Rating = 1;
            createCommentDto.CreatedTime = DateTime.Now;
            createCommentDto.status = false;
            createCommentDto.ProductId = "67263bc7943c14bfd1485b41";

            var response = await _commentService.CreateCommentAsync(createCommentDto);

            if (response == null)
            {
                return RedirectToAction("Index","Login");
            }

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { id = createCommentDto.ProductId });
            }

            return View();
        }
         

    }
}
