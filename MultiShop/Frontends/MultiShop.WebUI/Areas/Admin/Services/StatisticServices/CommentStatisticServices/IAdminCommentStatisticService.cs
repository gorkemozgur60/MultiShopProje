namespace MultiShop.WebUI.Areas.Admin.Services.StatisticServices.CommentStatisticServices
{
    public interface IAdminCommentStatisticService
    {
        Task<int?> GetActiveCommentCount();
        Task<int?> GetTotalCommentCount();
        Task<int?> GetPassiveCommentCount();
    }
}
