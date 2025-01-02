using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderResults;
using MultiShop.Order.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderHandlers
{
    public class GetOrderingByUserIdResultHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
    {
        private readonly IOrderingRepository _orderingRepository;

        public GetOrderingByUserIdResultHandler(IOrderingRepository orderingRepository)
        {
            _orderingRepository = orderingRepository;
        }

        public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = _orderingRepository.GetOrderingsByUserId(request.Id);
            return values.Select(x => new GetOrderingByUserIdQueryResult
            {
                OrderDate = x.OrderDate,
                UserId = x.UserId,
                OrderingId = x.OrderingId,
                TotalPrice = x.TotalPrice
            }).ToList();
        }
    }
}
