using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressComand createAddressComand)
        {
            await _repository.CreateAsync(new Address
            {
                UserId = createAddressComand.UserId,
                City = createAddressComand.City,
                Detail1 = createAddressComand.Detail1,
                District = createAddressComand.District,
                Name = createAddressComand.Name,
                Surname = createAddressComand.Surname,
                Email = createAddressComand.Email,
                Phone = createAddressComand.Phone,
                Country = createAddressComand.Country,
                Detail2 = createAddressComand.Detail2,
                Description = createAddressComand.Description,
                ZipCode = createAddressComand.ZipCode
            });
        }
    }
}
