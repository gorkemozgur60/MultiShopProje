using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using RabbitMQMessageApi.Controllers;
using System.Text;
using System.Text.Json;

namespace RabbitMQMessageApi.Services
{
    public class ReadOrder : IReadOrder
    {
        private static OrderDetailDto orderDetailDto;
        public async Task<OrderDetailDto> GetOrders()
        {

            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, x) =>
            {
                var byteMessage = x.Body.ToArray();
                var jsonMessage = Encoding.UTF8.GetString(byteMessage);
                orderDetailDto = JsonSerializer.Deserialize<OrderDetailDto>(jsonMessage);
            };

            channel.BasicConsume(queue: "Kuyruk12", autoAck: false, consumer: consumer);

            return orderDetailDto;
        }
    }
}
