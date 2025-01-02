using MultiShop.Order.Application.Features.Mediator.Results.OrderResults;
using MultiShop.Order.Domain.Entities;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.WebApi.OrderRabbitMq
{
    public class OrderConsumer
    {
        private readonly IConnection _connection;

        public OrderConsumer()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            _connection = factory.CreateConnection();
        }

        public void StarListening()
        {
            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: "OrderQueue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var orderMessage = JsonConvert.DeserializeObject<GetOrderQueryResult>(message);
            };
            channel.BasicConsume(queue: "OrderQueue", autoAck: true, consumer: consumer);
        }

    }
}
