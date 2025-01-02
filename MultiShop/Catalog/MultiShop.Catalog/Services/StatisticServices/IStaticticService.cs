namespace MultiShop.Catalog.Services.StatisticServices
{
    public interface IStaticticService
    {
        Task<long> GetCategoryCount();
        Task<long> GetProductCount();
        Task<long> GetBrandCount();
        Task<decimal> GetProductAvgCount();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
    }
}
