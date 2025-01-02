using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompany;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomer;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult GetAllCargoCustomer()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _cargoCustomerService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo Kullanıcısı başarıyla silindi!");
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDtos createCargoCustomerDtos)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Name = createCargoCustomerDtos.Name,
                Surname = createCargoCustomerDtos.Surname,
                City = createCargoCustomerDtos.City,
                Address = createCargoCustomerDtos.Address,
                District = createCargoCustomerDtos.District,
                Email = createCargoCustomerDtos.Email,
                Phone = createCargoCustomerDtos.Phone,
                UserCustomerId = createCargoCustomerDtos.UserCustomerId
            };

            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Kargo Kullanıcısı başarıyla eklendi!");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDtos updateCargoCustomerDtos)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Name = updateCargoCustomerDtos.Name,
                Surname = updateCargoCustomerDtos.Surname,
                Address = updateCargoCustomerDtos.Address,
                CargoCustomerId = updateCargoCustomerDtos.CargoCustomerId,
                City = updateCargoCustomerDtos.City,
                District = updateCargoCustomerDtos.District,
                Email = updateCargoCustomerDtos.Email,
                Phone = updateCargoCustomerDtos.Phone,
                UserCustomerId = updateCargoCustomerDtos.UserCustomerId
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo Kullanıcısı başarıyla güncellendi!");
        }

        [HttpGet("GetCargoCustomerById")]
        public IActionResult GetCargoCustomerById(string id)
        {
            return Ok(_cargoCustomerService.TGetCargoCustomerById(id));
        }
    }
}
