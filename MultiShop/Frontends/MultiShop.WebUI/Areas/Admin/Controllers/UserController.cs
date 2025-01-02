using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Areas.Admin.Services.CargoServices.CargoCustomerServices;
using MultiShop.WebUI.Areas.Admin.Services.UserListServices;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;
using MultiShop.WebUI.Services.IdentityUserLİstServices;
using MultiShop.WebUI.Services.Interface;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IIdentityUserListService _identityUserListService;
        private readonly IUserService _userService;
        private readonly IAdminCargoCustomerService _cargoCustomerService;

        public UserController(IIdentityUserListService identityUserListService, IAdminCargoCustomerService cargoCustomerService, IUserService userService)
        {
            _identityUserListService = identityUserListService;
            _cargoCustomerService = cargoCustomerService;
            _userService = userService;
        }

        public async Task<IActionResult> UserList()
        {
            var values = await _identityUserListService.GetUserListAsync();
            return View(values);
        }

        public async Task<IActionResult> UserAddressInfo(string id)
        {
            var values = await _cargoCustomerService.GetByIdCargoCustomerInfoAsync(id);
            return View(values);
        }
        
    }
}
