﻿using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderQueries
{
    public class GetByIdOrderQuery : IRequest<GetByIdOrderQueryResult>
    {
        public int Id { get; set; }

        public GetByIdOrderQuery(int id)
        {
            Id = id;
        }
    }
}