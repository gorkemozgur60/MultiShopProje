using RabbitMQMessageApi.Controllers;

namespace RabbitMQMessageApi.Services
{
    public interface ICreateOrder
    {
        Task CreateMessageAsync(CreateOrderDetailDto createOrderDetailDto);
    }
}
