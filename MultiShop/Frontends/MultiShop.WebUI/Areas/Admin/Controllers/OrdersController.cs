using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using MultiShop.WebUI.Areas.Admin.Services.OrderServices.OrderOrderingServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Orders")]
    public class OrdersController : Controller
    {
        private readonly IAdminOrderOrderingRabbitMq _rabbitMq;

        public OrdersController(IAdminOrderOrderingRabbitMq rabbitMq)
        {
            _rabbitMq = rabbitMq;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var orders = await _rabbitMq.GetAllOrder();
            return View(orders);
        }

        [HttpGet]
        [Route("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var order = await _rabbitMq.GetOrderDetailByOrderId(id);
            return View(order);
        }
    }
}
