using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.MessageServices
{
    public interface IAdminMessageService
    {
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id);
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
