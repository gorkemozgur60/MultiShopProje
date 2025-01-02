using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailsQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailsResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailsHandlers
{
    public class GetByIdOrderDetailsHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetByIdOrderDetailsHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailsByIdQueryResult> Handler(GetByIdQueryOrderDetails getByIdQueryOrder)
        {
            var values = await _repository.GetByIdAsync(getByIdQueryOrder.Id);
            return new GetOrderDetailsByIdQueryResult
            {
                OrderDetailId = values.OrderDetailId,
                ProductAmount = values.ProductAmount,
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                ProductPrice = values.ProductPrice,
                ProductTotalPrice = values.ProductTotalPrice,
                OrderingId = values.OrderingId,
            };
        }
        

    }
}

