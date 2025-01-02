using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.OrderServices.OrderOrderingServices
{
    public interface IAdminOrderOrderingRabbitMq
    {
        Task<List<ResultOrderingByUserIdDto>> GetAllOrder();
        Task<GetOrderDetailsResult> GetOrderDetailByOrderId(int id);
    }
}
