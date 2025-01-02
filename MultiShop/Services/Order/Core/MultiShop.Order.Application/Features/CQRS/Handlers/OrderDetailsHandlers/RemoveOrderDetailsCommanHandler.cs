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
    public class RemoveOrderDetailsCommanHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public RemoveOrderDetailsCommanHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderDetailsCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
