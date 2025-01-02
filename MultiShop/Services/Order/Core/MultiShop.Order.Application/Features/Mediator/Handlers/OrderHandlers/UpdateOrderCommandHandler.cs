using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.OrderingId);
            values.OrderDate = request.OrderDate;
            values.OrderingId = request.OrderingId;
            values.UserId = request.UserId;
            values.TotalPrice = request.TotalPrice;
            await _repository.UpdateAsync(values);

        }
    }
}
