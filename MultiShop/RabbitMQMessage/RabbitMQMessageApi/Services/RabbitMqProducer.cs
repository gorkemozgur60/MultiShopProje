using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQMessageApi.Services
{
    public class RabbitMqProducer
    {
        public void SendOrder(string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" }; // RabbitMQ Sunucusu
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            // Kuyruk tanımlama
            channel.QueueDeclare(queue: "kuyruks",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            // Mesaj gönderme
            channel.BasicPublish(exchange: "",
                                 routingKey: "kuyruks",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine($"[Producer] Kuyruğa Mesaj Gönderildi: {message}");
        }

        public void ReceiveOrder(string message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, args) =>
            {
                var byteMessage = args.Body.ToArray();
                message = Encoding.UTF8.GetString(byteMessage);
            };

            channel.BasicConsume(queue: "Kuyruk1", autoAck: false, consumer: consumer);
        }
    }
}
