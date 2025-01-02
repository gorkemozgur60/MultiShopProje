using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _specialBrandCollection;
        public IMapper _mapper;

        public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _specialBrandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrand createBrandDto)
        {
            var value = _mapper.Map<Brand>(createBrandDto);
            await _specialBrandCollection.InsertOneAsync(value);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _specialBrandCollection.DeleteOneAsync(x => x.BrandId == id);
        }

        public async Task<List<ResultBrand>> GetAllBrandAsync()
        {
            var values = await _specialBrandCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBrand>>(values);
        }

        public async Task<GetByBrand> GetByIdBrandAsync(string id)
        {
            var values = await _specialBrandCollection.Find<Brand>(x => x.BrandId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByBrand>(values);
        }

        public async Task UpdateBrandAsync(UpdateBrand updateBrandDto)
        {
            var values = _mapper.Map<Brand>(updateBrandDto);
            await _specialBrandCollection.FindOneAndReplaceAsync(x => x.BrandId == updateBrandDto.BrandId, values);
        }
    }
}
