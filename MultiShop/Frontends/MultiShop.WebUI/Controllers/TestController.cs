using Amazon.Runtime.Internal.Transform;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Controllers
{
    public class TestController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ICategoryService _categoryService;
        public TestController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
		{
			string token = "";

			using(var httpClient = new HttpClient())
			{
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Post,
					RequestUri = new Uri("http://localhost:5001/connect/token"),
					Content = new FormUrlEncodedContent(new Dictionary<string, string>
					{
						{"client_id" , "MultiShopVisitorId" },
						{"client_secret" , "multishopsecret" },
						{"grant_type", "client_credentials" }
					})
				};

				using(var response = await httpClient.SendAsync(request))
				{
					if(response.IsSuccessStatusCode)
					{ 
						var content = await response.Content.ReadAsStringAsync();
						var tokenResponse = JObject.Parse(content);
						token = tokenResponse["access_token"].ToString();
					}
				}
			}

			var client = _httpClientFactory.CreateClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			var responseMessage = await client.GetAsync("http://localhost:7069/api/Category");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategory>>(jsonData);
				return View(values);
			}
			return View();
		}

        public IActionResult Deneme1()
        {
            return View();
        }

        public async Task<IActionResult> Deneme2()
        {
			var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
