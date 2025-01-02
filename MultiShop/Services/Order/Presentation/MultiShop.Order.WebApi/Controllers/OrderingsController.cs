using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderResults;
using MultiShop.Order.WebApi.OrderRabbitMq;
namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IOrderServiceRabbitMq _rabbitMq;

        public OrderingsController(IMediator mediator, IOrderServiceRabbitMq rabbitMq)
        {
            _mediator = mediator;
            _rabbitMq = rabbitMq;
        }


        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetOrderQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderingById(int id)
        {
            var value = await _mediator.Send(new GetByIdOrderQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> OrderingCreate(CreateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kayıt Başarılı!");
        }

        [HttpDelete]
        public async Task<IActionResult> OrderingDelete(int id)
        {
            await _mediator.Send(new RemoveOrderCommand(id));
            return Ok("Silme işlemi başarılı!");
        }

        [HttpPut]
        public async Task<IActionResult> OrderingUpdate(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelleme başarılı!");
        }

        [HttpGet("GetOrderingByUserId/{id}")]
        public async Task<IActionResult> GetOrderingByUserId(string id)
        {
            var values = await _mediator.Send(new GetOrderingByUserIdQuery(id));
            return Ok(values);
        }

        [HttpGet("GetAllOrder")]
        public async Task<IActionResult> List()
        {
            var orders = await _rabbitMq.GetAllOrderAsync();
            return Ok(orders);
        }

        

    }
}
