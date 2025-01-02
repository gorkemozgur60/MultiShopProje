using MultiShop.DtoLayer.CargoDtos.CargoCustomer;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerDto> GetByIdCargoCustomerInfoAsync(string id);
    }
}
