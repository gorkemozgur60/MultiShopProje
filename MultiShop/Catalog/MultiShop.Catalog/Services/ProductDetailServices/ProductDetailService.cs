﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductDetail> _productsDetailCollection;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings) 
        { 
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productsDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productsDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productsDetailCollection.DeleteOneAsync(x=> x.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productsDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetByProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var value = await _productsDetailCollection.Find<ProductDetail>(x => x.ProductDetailId== id).FirstOrDefaultAsync();
            return _mapper.Map<GetByProductDetailDto>(value);
        }

        public async Task<GetByProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {
            var value = await _productsDetailCollection.Find<ProductDetail>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByProductDetailDto>(value);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productsDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId ,value);
        }
    }
}
