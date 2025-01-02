﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoryCollection;

        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
            
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createcategoryDto)
        {
            var value = _mapper.Map<Category>(createcategoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByCategoryDto> GetByIdCategoriesAsync(string id)
        {
            var values = await _categoryCollection.Find<Category>(x => x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByCategoryDto>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updatecategoryDto)
        {
            var values = _mapper.Map<Category>(updatecategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updatecategoryDto.CategoryId,values);
        }
    }
}
