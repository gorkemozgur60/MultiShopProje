using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailsCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailsHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailsQueries;
using MultiShop.Order.WebApi.OrderRabbitMq;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        public readonly CreateOrderDetailsCommandHandler _createOrderDetailsCommandHandler;
        public readonly GetByIdOrderDetailsHandler _getByIdOrderDetailsHandler;
        public readonly GetOrderDetailsHandler _getOrderDetailsHandler;
        public readonly RemoveOrderDetailsCommanHandler _removeOrderDetailsCommanHandler;
        public readonly UpdateOrderDetailsCommanHandler _updateOrderDetailsCommanHandler;
        private readonly IOrderServiceRabbitMq _rabbitMq;

        public OrderDetailsController(UpdateOrderDetailsCommanHandler updateOrderDetailsCommanHandler, RemoveOrderDetailsCommanHandler removeOrderDetailsCommanHandler, GetOrderDetailsHandler getOrderDetailsHandler, GetByIdOrderDetailsHandler getByIdOrderDetailsHandler, CreateOrderDetailsCommandHandler createOrderDetailsCommandHandler, IOrderServiceRabbitMq rabbitMq)
        {
            _updateOrderDetailsCommanHandler = updateOrderDetailsCommanHandler;
            _removeOrderDetailsCommanHandler = removeOrderDetailsCommanHandler;
            _getOrderDetailsHandler = getOrderDetailsHandler;
            _getByIdOrderDetailsHandler = getByIdOrderDetailsHandler;
            _createOrderDetailsCommandHandler = createOrderDetailsCommandHandler;
            _rabbitMq = rabbitMq;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            var values = await _getOrderDetailsHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdOrderDetails(int id)
        {
            var values = await _getByIdOrderDetailsHandler.Handler(new GetByIdQueryOrderDetails(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetails(CreateOrderDetailsCommand command)
        {
            await _createOrderDetailsCommandHandler.Handle(command);
            return Ok("Kayıt Başırılı!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetails(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailsCommanHandler.Handle(command);
            return Ok("Güncelleme Başarılı!");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetails(int id)
        {
            await _removeOrderDetailsCommanHandler.Handle(new RemoveOrderDetailsCommand(id));
            return Ok("Silme işlemi Başarılı!");
        }

        [HttpGet("GetOrderDetailByOrderId/{id}")]
        public async Task<IActionResult> GetUserIdOrder(int id)
        {
            var orders = await _rabbitMq.GetOrderDetailByOrderIdAsync(id);
            return Ok(orders);
        }
    }
}
