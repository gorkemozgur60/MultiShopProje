using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Mapper
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() 
        {
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, GetByProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();

            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetByCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();

            
            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();


            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();

            CreateMap<Product,ResultProductsWithCategoryDto>().ReverseMap();

            CreateMap<FeatureSlider,ResultFeatureSlider>().ReverseMap();
            CreateMap<FeatureSlider,UpdateFeatureSlider>().ReverseMap();
            CreateMap<FeatureSlider,CreateFeatureSlider>().ReverseMap();
            CreateMap<FeatureSlider,GetByFeautureSlider>().ReverseMap();

            CreateMap<SpecialOffer,ResultSpecialOffer>().ReverseMap();
            CreateMap<SpecialOffer,UpdateSpecialOffer>().ReverseMap();
            CreateMap<SpecialOffer,CreateSpecialOffer>().ReverseMap();
            CreateMap<SpecialOffer,GetBySpecialOffer>().ReverseMap();

            CreateMap<Feature, ResultFeature>().ReverseMap();
            CreateMap<Feature, UpdateFeature>().ReverseMap();
            CreateMap<Feature, CreateFeature>().ReverseMap();
            CreateMap<Feature, GetByFeature>().ReverseMap();

            CreateMap<OfferDiscount,CreateOfferDiscount>().ReverseMap();
            CreateMap<OfferDiscount,UpdateOfferDiscount>().ReverseMap();
            CreateMap<OfferDiscount,GetByOfferDiscount>().ReverseMap();
            CreateMap<OfferDiscount,ResultOfferDiscount>().ReverseMap();


            CreateMap<Brand,ResultBrand>().ReverseMap();
            CreateMap<Brand,UpdateBrand>().ReverseMap();
            CreateMap<Brand,CreateBrand>().ReverseMap();
            CreateMap<Brand,GetByBrand>().ReverseMap();

            CreateMap<About, GetByAbout>().ReverseMap();
            CreateMap<About, UpdateAbout>().ReverseMap();
            CreateMap<About, CreateAbout>().ReverseMap();
            CreateMap<About, ResultAbout>().ReverseMap();

            CreateMap<Contact, GetByContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, ResultContactDto>().ReverseMap();
        }
    }
}
