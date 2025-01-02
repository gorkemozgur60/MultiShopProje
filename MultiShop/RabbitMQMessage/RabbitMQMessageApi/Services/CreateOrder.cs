using RabbitMQ.Client;
using RabbitMQMessageApi.Controllers;
using System.Text;
using System.Text.Json;

namespace RabbitMQMessageApi.Services
{
    public class CreateOrder : ICreateOrder
    {
        public async Task CreateMessageAsync(CreateOrderDetailDto createOrderDetailDto)
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("Kuyruk12", false, false, false, arguments: null);

            var jsonMessage = JsonSerializer.Serialize(createOrderDetailDto);

            var byteMessageContent = Encoding.UTF8.GetBytes(jsonMessage);

            channel.BasicPublish(exchange: "", routingKey: "Kuyruk12", basicProperties: null, body: byteMessageContent);
        }
    }
}
