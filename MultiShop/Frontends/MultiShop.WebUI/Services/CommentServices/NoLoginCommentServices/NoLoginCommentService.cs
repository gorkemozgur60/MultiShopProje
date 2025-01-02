using MultiShop.DtoLayer.CommentDtos;
using System.Net.Http;

namespace MultiShop.WebUI.Services.CommentServices.NoLoginCommentServices
{
    public class NoLoginCommentService : INoLoginCommentService
    {
        private readonly HttpClient _httpClient;

        public NoLoginCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultCommentDto>> CommentListByProductId(string id)
        {
            var response = await _httpClient.GetAsync("comments/commentlistbyproductid/" + id);
            var values = await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>("comments/commentlistbyproductid/" + id);
            return values;
        }
    }
}
