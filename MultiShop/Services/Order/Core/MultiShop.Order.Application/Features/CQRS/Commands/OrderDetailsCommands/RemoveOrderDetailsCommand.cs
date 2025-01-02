using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailsCommands
{
    public class RemoveOrderDetailsCommand
    {
        public int Id { get; set; }

        public RemoveOrderDetailsCommand(int id)
        {
            Id = id;
        }
    }
}
