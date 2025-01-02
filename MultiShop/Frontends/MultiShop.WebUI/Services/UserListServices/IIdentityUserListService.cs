using MultiShop.DtoLayer.IdentityDtos.UserListDtos;

namespace MultiShop.WebUI.Services.IdentityUserLİstServices
{
    public interface IIdentityUserListService
    {
        Task<List<ResultUserListDto>> GetUserListAsync();
    }
}
