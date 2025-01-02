using MultiShop.DtoLayer.CommentDtos;
using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Services.CommentServices
{
    public class AdminCommentService : IAdminCommentService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminCommentService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<ResultCommentDto>> CommentListByProductId(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>("comments/commentlistbyproductid/" + id);
            return values;
        }

        public async Task<HttpResponseMessage> CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            var values = await _httpClient.PostAsJsonAsync("comments", createCommentDto);
            return values;
        }

        public async Task<HttpResponseMessage> DeleteCommentAsync(string id)
        {
            var values = await _httpClient.DeleteAsync("comment/" + id);
            return values;
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            var repsonse = await _httpClient.GetAsync("comments");

            if(repsonse.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>("comments");
            return values;
        }

        public async Task<UpdateCommentDto> GetByIdCommentAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateCommentDto>("comments/" + id);
            return values;
        }

        public async Task<HttpResponseMessage> UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            var values = await _httpClient.PutAsJsonAsync("comments", updateCommentDto);
            return values;
        }

        public async Task<int> GetTotalCommentCount()
        {
            var values = await _httpClient.GetFromJsonAsync<int>("comments/GetTotalCommentCount");
            return values;
        }
    }
}
