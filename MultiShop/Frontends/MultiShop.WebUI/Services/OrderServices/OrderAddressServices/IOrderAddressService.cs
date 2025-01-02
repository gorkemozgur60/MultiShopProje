using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
    }
}
