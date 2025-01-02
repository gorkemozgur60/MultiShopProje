using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ContactServices
{
    public interface IAdminContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(string id);
        Task<GetByContactDto> GetByIdContactAsync(string id);
    }
}
