using MultiShop.DtoLayer.CommentDtos;
using MultiShop.DtoLayer.IdentityDtos.RegisterDtos;

namespace MultiShop.WebUI.Services.RegisterServices
{
    public interface IRegisterService
    {
        Task<HttpResponseMessage> CreateRegister(CreateRegisterDto createRegisterDto);
    }
}
