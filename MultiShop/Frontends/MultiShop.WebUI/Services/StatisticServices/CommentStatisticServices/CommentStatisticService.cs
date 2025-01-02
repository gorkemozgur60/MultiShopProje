namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _httpClient;

        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetActiveCommentCount()
        {
            var values = await _httpClient.GetFromJsonAsync<int>("comments/GetPassiveCommentCount");
            return values;
        }

        public async Task<int> GetPassiveCommentCount()
        {
            var values = await _httpClient.GetFromJsonAsync<int>("comments/GetPassiveCommentCount");
            return values;
        }

        public async Task<int> GetTotalCommentCount()
        {
            var values = await _httpClient.GetFromJsonAsync<int>("comments/GetPassiveCommentCount");
            return values;
        }
    }
}
