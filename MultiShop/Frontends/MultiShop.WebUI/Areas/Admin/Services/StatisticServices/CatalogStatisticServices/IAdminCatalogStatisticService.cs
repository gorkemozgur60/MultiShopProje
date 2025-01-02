namespace MultiShop.WebUI.Areas.Admin.Services.StatisticServices.CatalogStatisticServices
{
    public interface IAdminCatalogStatisticService
    {
        Task<long?> GetCategoryCount();
        Task<long?> GetProductCount();
        Task<long?> GetBrandCount();
        Task<decimal?> GetProductAvgCount();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
    }
}
