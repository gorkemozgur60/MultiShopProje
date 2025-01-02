using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id);
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
