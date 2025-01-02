using MultiShop.Order.Application.Features.Mediator.Results.OrderResults;
using MultiShop.Order.Domain.Entities;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.WebApi.OrderRabbitMq
{
    public class OrderProducer
    {
        private readonly IConnection _connection;

        public OrderProducer()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            _connection = factory.CreateConnection();
        }

        public void SendOrderMessage(GetOrderQueryResult resultOrdering)
        {
            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: "OrderQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(resultOrdering));

            channel.BasicPublish(exchange: "", routingKey: "OrderQueue", basicProperties: null, body: body);
        }
    }
}
