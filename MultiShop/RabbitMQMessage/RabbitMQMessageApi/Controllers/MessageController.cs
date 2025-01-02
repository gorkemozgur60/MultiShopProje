using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {


        [HttpGet]
        public IActionResult CreateMessage(CreateOrderDetailDto createOrderDetailDto)
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("Kuyruk2",false,false,false,arguments:null);

            var jsonMessage = JsonSerializer.Serialize(createOrderDetailDto);

            var byteMessageContent = Encoding.UTF8.GetBytes(jsonMessage);

            channel.BasicPublish(exchange:"",routingKey:"Kuyruk2",basicProperties:null,body:byteMessageContent);

            return Ok("Mesajınız Kuyruğa Alınmıştır.");
        }

        private static OrderDetailDto orderDetailDto;

        [HttpPost]
        public IActionResult ReadMessage()
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

            channel.BasicConsume(queue:"Kuyruk1",autoAck:false,consumer:consumer);

            return Ok(orderDetailDto);
        }
    }
}
