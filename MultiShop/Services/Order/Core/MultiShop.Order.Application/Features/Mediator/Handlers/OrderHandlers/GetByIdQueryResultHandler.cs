using MediatR;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderHandlers
{
    public class GetByIdQueryResultHandler : IRequestHandler<GetByIdOrderQuery, GetByIdOrderQueryResult>
    {
        private readonly IRepository<Ordering> _repository;

        public GetByIdQueryResultHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdOrderQueryResult> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetByIdOrderQueryResult
            {
                OrderDate = value.OrderDate,
                OrderingId = value.OrderingId,
                TotalPrice = value.TotalPrice,
                UserId = value.UserId
            };
        }
    }
}
