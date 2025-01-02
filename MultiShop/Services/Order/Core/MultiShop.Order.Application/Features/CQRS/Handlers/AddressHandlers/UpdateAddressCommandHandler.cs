using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressComand update)
        {
            var values = await _repository.GetByIdAsync(update.AddressId);
            values.Detail1 = update.Detail;
            values.District = update.District;
            values.City = update.City;
            values.UserId = update.UserId;
            await _repository.UpdateAsync(values);
        }
        
    }
}
