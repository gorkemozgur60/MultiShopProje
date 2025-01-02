using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailsResults;
using MultiShop.Order.Application.Features.Mediator.Handlers.OrderHandlers;
using MultiShop.Order.Application.Features.Mediator.Results.OrderResults;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.WebApi.OrderRabbitMq
{
    public class OrderServiceRabbitMq : IOrderServiceRabbitMq
    {
        private readonly OrderContext _context;
        public OrderServiceRabbitMq(OrderContext context)
        {
            _context = context;
        }

        public async Task<List<GetOrderQueryResult>> GetAllOrderAsync()
        {
            var values = await _context.Orderings.ToListAsync();

            if (values == null || !values.Any())
            {
                Console.WriteLine("No data found in the Orderings table.");
                return new List<GetOrderQueryResult>();
            }

            return values.Select(x => new GetOrderQueryResult
            {
                OrderDate = x.OrderDate,
                UserId = x.UserId,
                OrderingId = x.OrderingId,
                TotalPrice = x.TotalPrice
            }).ToList();
        }

        public async Task<GetOrderDetailsQueryResult> GetOrderDetailByOrderIdAsync(int id)
        {
            var values = await _context.Orderings.SingleOrDefaultAsync(o => o.OrderingId == id);

            if (values == null)
            {
                return new GetOrderDetailsQueryResult();
            }

            return new GetOrderDetailsQueryResult
            {
                OrderingId = values.OrderingId,
                ProductName = values.UserId,
                ProductTotalPrice = values.TotalPrice
            };
        }
    }
}
