namespace MultiShop.WebUI.Areas.Admin.Services.StatisticServices.MessageStatisticServices
{
    public interface IAdminMessageStatisticService
	{
        Task<int?> GetMessageCount();
    }
}
