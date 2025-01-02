
namespace MultiShop.SignalRRealTime.Services.SignalRCommentServices
{
    public class SignalRCommentService : ISignalRCommentService
    {
        private readonly HttpClient _httpClient;

        public SignalRCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalCommentCount()
        {
            var values = await _httpClient.GetFromJsonAsync<int>("http://localhost:7075/api/CommentStatistic");
            return values;
        }
    }
}
