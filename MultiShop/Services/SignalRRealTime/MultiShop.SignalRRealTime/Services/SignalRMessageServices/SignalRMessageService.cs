namespace MultiShop.SignalRRealTime.Services.SignalRMessageServices
{
    public class SignalRMessageService:ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<int>("http://localhost:7078/api/UserMessageStatistic/GetTotalMessageCountByReceiverId/" + id);
            return values;
        }
    }
}
