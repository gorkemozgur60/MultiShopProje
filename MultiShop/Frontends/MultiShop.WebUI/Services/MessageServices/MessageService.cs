using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultInboxMessageDto>>("usermessage/getmessageinbox?id=" + id);
            return values;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultSendboxMessageDto>>("usermessage/getmessagesendbox?id=" + id);
            return values;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<int>("usermessage/GetTotalMessageCountByReceiverId/" + id);
            return values;
        }
    }
}
