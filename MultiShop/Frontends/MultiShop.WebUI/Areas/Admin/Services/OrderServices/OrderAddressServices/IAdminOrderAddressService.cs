using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.OrderServices.OrderAddressServices
{
    public interface IAdminOrderAddressService
    {
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
    }
}
