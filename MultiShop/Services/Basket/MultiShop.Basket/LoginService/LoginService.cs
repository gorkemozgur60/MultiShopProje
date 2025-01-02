using System.Security.Claims;

namespace MultiShop.Basket.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public LoginService(IHttpContextAccessor httpcontextAccessor)
        {
            _httpcontextAccessor = httpcontextAccessor;
        }

        public string GetUserId => _httpcontextAccessor.HttpContext.User.FindFirst("sub").Value;


    }
}
