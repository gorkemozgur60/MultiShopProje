using MultiShop.WebUI.Areas.Admin.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;

namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServcies
{
    public class MessageStatisticService : IMessageStatisticService
    {
        private readonly HttpClient _httpClient;

        public MessageStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetMessageCount()
        {
            var values = await _httpClient.GetFromJsonAsync<int>("UserMessage/GetMessageCount");
            return values;
        }
    }
}
