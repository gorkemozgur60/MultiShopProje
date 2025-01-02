using RabbitMQMessageApi.Controllers;

namespace RabbitMQMessageApi.Services
{
    public interface IReadOrder
    {
        Task<OrderDetailDto> GetOrders();
    }
}
