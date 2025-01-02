namespace RabbitMQMessageApi.Controllers
{
    public class OrderDetailDto
    {
        public string OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
    }
}
