using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using System.Runtime.CompilerServices;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;

        public AddressController(CreateAddressCommandHandler createAddressCommandHandler, GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, RemoveAddressCommandHandler removeAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler)
        {
            _createAddressCommandHandler = createAddressCommandHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _getAddressQueryHandler = getAddressQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await _getAddressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id)
        {
            var values = await _getAddressByIdQueryHandler.Handle(new GetByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressComand comand)
        {
            await _createAddressCommandHandler.Handle(comand);
            return Ok("Kayıt Başarılı!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressComand comand)
        {
            await _updateAddressCommandHandler.Handle(comand);
            return Ok("Güncelleme Başarılı!");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressComand(id));
            return Ok("Silme işlemi Başarılı!");
        }
    }
}
