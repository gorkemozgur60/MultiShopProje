using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompany;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult GetAllCargoCompany()
        {
            var values = _cargoCompanyService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDtos createCompanyDtos)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName = createCompanyDtos.CargoCompanyName,
            };
            _cargoCompanyService.TInsert(cargoCompany);
            return Ok("Kargo Şirketi başarıyla eklendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var values = _cargoCompanyService.TGetById(id);
            return Ok(values);
        }

        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Kargo Şirketi başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDtos updateCompanyDtos)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName = updateCompanyDtos.CargoCompanyName,
                CustomerCompanyId = updateCompanyDtos.CustomerCompanyId,
            };
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Kargo Şirketi başarıyla güncellendi!");
        }

    }
}
