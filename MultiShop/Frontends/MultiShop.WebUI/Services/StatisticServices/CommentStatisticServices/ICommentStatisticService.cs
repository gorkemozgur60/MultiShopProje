namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public interface ICommentStatisticService
    {
        Task<int> GetActiveCommentCount();
        Task<int> GetTotalCommentCount();
        Task<int> GetPassiveCommentCount();
    }
}
