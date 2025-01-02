using MultiShop.DtoLayer.CargoDtos.CargoCompany;

namespace MultiShop.WebUI.Areas.Admin.Services.CargoServices.CargoCompanyServices
{
    public interface IAdminCargoCompanyService
    {
        Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync();
        Task CreateCargoCompanyAsync(CreateCargoCompanyDto cargoCompanyDto);
        Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto cargoCompanyDto);
        Task DeleteCargoCompanyAsync(int id);
        Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id);

    }
}
