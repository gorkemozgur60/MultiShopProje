using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperation;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult GetAllCargoOperation()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _cargoOperationService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo Kullanıcısı başarıyla silindi!");
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDtos createCargoOperationDtos)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = createCargoOperationDtos.Barcode,
                Description = createCargoOperationDtos.Description,
                OperationDate = createCargoOperationDtos.OperationDate
            };

            _cargoOperationService.TInsert(cargoOperation);
            return Ok("Kargo Kullanıcısı başarıyla eklendi!");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDtos updateCargoOperationDtos)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode= updateCargoOperationDtos.Barcode,
                CargoOperationId = updateCargoOperationDtos.CargoOperationId,
                Description = updateCargoOperationDtos.Description,
                OperationDate = updateCargoOperationDtos.OperationDate
            };
            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Kargo Kullanıcısı başarıyla güncellendi!");
        }
    }
}
