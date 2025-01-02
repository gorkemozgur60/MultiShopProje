using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("UserRegister")]
        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto registerDto)
        {

			if (!Regex.IsMatch(registerDto.Name, @"^[a-zA-ZığüşöçİĞÜŞÖÇ\s]+$"))
			{
				return BadRequest("İsim yalnızca harflerden oluşmalıdır.");
			}

			if (!Regex.IsMatch(registerDto.Surname, @"^[a-zA-ZığüşöçİĞÜŞÖÇ\s]+$"))
			{
				return BadRequest("Soyisim yalnızca harflerden oluşmalıdır.");
			}

			if (!registerDto.Username.Any(char.IsLetter))
			{
				return BadRequest("Kullanıcı adı en az bir harf içermelidir.");
			}

			if (registerDto.Password != registerDto.PasswordConfirm)
			{
				return BadRequest("Şifreler eşleşmedi");
			}

			var existingUser = await _userManager.FindByNameAsync(registerDto.Username);

			if (existingUser != null)
			{
				return BadRequest("Bu kullanıcı adı zaten kullanılıyor.");
			}

			var existingEmail = await _userManager.FindByEmailAsync(registerDto.Email);

			if (existingEmail != null)
			{
				return BadRequest("Bu e-posta adresi zaten kayıtlı.");
			}

			var values = new ApplicationUser()
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                Name = registerDto.Name,
                Surname = registerDto.Surname,
            };

			var result = await _userManager.CreateAsync(values, registerDto.Password);
            var resultt = await _userManager.CreateAsync(values,registerDto.PasswordConfirm);

			if (result.Succeeded && resultt.Succeeded)
            {
                return Ok("Kullanıcı başarıyla eklendi!");
            }
            else
            {
				return BadRequest("Şifre en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.");
			}

			

		}


	}
}
