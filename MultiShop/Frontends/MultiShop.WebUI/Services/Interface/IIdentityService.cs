using MultiShop.DtoLayer.IdentityDtos.LoginDtos;

namespace MultiShop.WebUI.Services.Interface
{
	public interface IIdentityService
	{
		Task<bool> SignIn(SignInDto signUpDto);
		Task<bool> SignInAdminPanel(SignInDto signUpDto);
		Task<bool> GetRefreshToken();
		Task<bool> GetRefreshTokenAdmin();
	}
}
