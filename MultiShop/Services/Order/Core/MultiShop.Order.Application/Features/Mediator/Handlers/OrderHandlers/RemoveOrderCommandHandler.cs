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
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public RemoveOrderCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
