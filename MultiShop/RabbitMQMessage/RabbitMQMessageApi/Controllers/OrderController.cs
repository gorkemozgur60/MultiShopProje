using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQMessageApi.Services;

namespace RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICreateOrder _createOrder;
        private readonly IReadOrder _readOrder;

        public OrderController(ICreateOrder createOrder, IReadOrder readOrder)
        {
            _createOrder = createOrder;
            _readOrder = readOrder;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateOrder(CreateOrderDetailDto createorderDetailDto)
        {
            _createOrder.CreateMessageAsync(createorderDetailDto);
            return Ok("Sipariş Kuyruğa Alındı");
        }

        [HttpGet]
        [Route("read")]
        public async Task<IActionResult> ReadOrder()
        {
            var values = await _readOrder.GetOrders();
            return Ok(values);
        }
    }
}
