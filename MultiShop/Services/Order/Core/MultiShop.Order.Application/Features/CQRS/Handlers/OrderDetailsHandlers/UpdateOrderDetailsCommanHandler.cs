using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
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
    public class UpdateOrderDetailsCommanHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailsCommanHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.OrderDetailId);
            values.ProductName = command.ProductName;
            values.ProductPrice = command.ProductPrice;
            values.ProductTotalPrice = command.ProductTotalPrice;
            values.ProductId = command.ProductId;
            values.ProductAmount = command.ProductAmount;
            values.OrderingId = command.OrderingId;
            await _repository.UpdateAsync(values);
        }
    }
}
