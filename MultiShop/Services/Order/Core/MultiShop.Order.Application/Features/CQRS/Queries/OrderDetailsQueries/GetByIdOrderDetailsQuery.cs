using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailsQueries
{
    public class GetByIdQueryOrderDetails
    {
        public int Id { get; set; }

        public GetByIdQueryOrderDetails(int id)
        {
            Id = id; 
        }
    }
}
