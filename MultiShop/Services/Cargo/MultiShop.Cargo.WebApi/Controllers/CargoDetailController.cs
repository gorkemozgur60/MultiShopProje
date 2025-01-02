using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetail;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult GetAllCargoDetail()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo Kullanıcısı başarıyla silindi!");
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDtos createCargoDetailDtos)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = createCargoDetailDtos.Barcode,
                ReceiverCustomer = createCargoDetailDtos.ReceiverCustomer,
                SenderCustomer =    createCargoDetailDtos.SenderCustomer,
                CargoCompanyId = createCargoDetailDtos.CargoCompanyId,
            };

            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo Kullanıcısı başarıyla eklendi!");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDtos updateCargoDetailDtos)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                CargoDetailId = updateCargoDetailDtos.CargoDetailId,
                Barcode = updateCargoDetailDtos.Barcode,
                ReceiverCustomer = updateCargoDetailDtos.ReceiverCustomer,
                SenderCustomer = updateCargoDetailDtos.SenderCustomer,
                CargoCompanyId = updateCargoDetailDtos.CargoCompanyId,
            };
            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("Kargo Kullanıcısı başarıyla güncellendi!");
        }
    }
}
