using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailsResults;
using MultiShop.Order.Application.Features.Mediator.Results.OrderResults;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.WebApi.OrderRabbitMq
{
    public interface IOrderServiceRabbitMq
    {
        Task<List<GetOrderQueryResult>> GetAllOrderAsync();
        Task<GetOrderDetailsQueryResult> GetOrderDetailByOrderIdAsync(int id);
    }
}
