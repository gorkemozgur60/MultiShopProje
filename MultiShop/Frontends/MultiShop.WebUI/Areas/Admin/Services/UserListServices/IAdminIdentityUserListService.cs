using MultiShop.DtoLayer.IdentityDtos.UserListDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.UserListServices
{
    public interface IAdminIdentityUserListService
    {
        Task<List<ResultUserListDto>> GetUserListAsync();
    }
}
