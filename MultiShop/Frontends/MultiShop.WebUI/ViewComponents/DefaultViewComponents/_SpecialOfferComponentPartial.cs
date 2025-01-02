using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.SpecialOfferServices;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;


namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferComponentPartial: ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;

        public _SpecialOfferComponentPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {

            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }

    }
}
