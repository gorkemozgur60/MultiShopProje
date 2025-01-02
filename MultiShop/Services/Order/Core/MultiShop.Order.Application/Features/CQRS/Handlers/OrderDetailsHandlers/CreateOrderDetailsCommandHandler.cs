using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailsCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailsHandlers
{
    public class CreateOrderDetailsCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailsCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailsCommand createOrderDetails)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                OrderingId = createOrderDetails.OrderingId,
                ProductTotalPrice = createOrderDetails.ProductTotalPrice,
                ProductPrice = createOrderDetails.ProductPrice,
                ProductName = createOrderDetails.ProductName,
                ProductId = createOrderDetails.ProductId,
                ProductAmount = createOrderDetails.ProductAmount,
            });
        }
    }
}
