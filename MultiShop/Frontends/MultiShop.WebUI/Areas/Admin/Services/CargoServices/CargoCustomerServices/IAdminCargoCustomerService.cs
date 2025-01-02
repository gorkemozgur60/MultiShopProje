using MultiShop.DtoLayer.CargoDtos.CargoCustomer;

namespace MultiShop.WebUI.Areas.Admin.Services.CargoServices.CargoCustomerServices
{
    public interface IAdminCargoCustomerService
    {
        Task<GetCargoCustomerDto> GetByIdCargoCustomerInfoAsync(string id);
    }
}
