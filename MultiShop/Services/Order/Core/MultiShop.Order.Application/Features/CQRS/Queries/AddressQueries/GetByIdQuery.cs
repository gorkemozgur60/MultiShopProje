using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetByIdQuery
    {
        public int Id { get; set; }
        public GetByIdQuery(int id) 
        {
            Id = id;
        }
    }
}
