using MultiShop.DtoLayer.CommentDtos;
using System.Net;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public CommentService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
        }

        public async Task<HttpResponseMessage> CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            var response = await _httpClient.GetAsync("comments");

            if (response.StatusCode == HttpStatusCode.Found)
            {
                _contextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }
            var values = await _httpClient.PostAsJsonAsync<CreateCommentDto>("comments", createCommentDto);
            return values;
        }

        public async Task DeleteCommentAsync(string id)
        {
            await _httpClient.DeleteAsync("comment/"+id);
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>("comments");
            return values;
        }

        public async Task<UpdateCommentDto> GetByIdCommentAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateCommentDto>("comments/" + id);
            return values;
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCommentDto>("comments", updateCommentDto);
        }

        public async Task<int> GetTotalCommentCount()
        {
            var values = await _httpClient.GetFromJsonAsync<int>("comments/GetTotalCommentCount");
            return values;
        }
    }
}
