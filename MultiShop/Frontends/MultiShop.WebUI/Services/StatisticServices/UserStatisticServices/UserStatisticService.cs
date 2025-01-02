namespace MultiShop.WebUI.Services.StatisticServices.UserStatisticServices
{
    public class UserStatisticService : IUserStatisticService
    {
        private readonly HttpClient _httpClient;

        public UserStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetAllUserCount()
        {
            var values = await _httpClient.GetFromJsonAsync<int>("statistics/getallusercount");
            return values;
        }
    }
}
