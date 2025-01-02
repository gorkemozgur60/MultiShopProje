using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Feature> _featureCollection;
        public FeatureService(IMapper mapper , IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeature createfeatereDto)
        {
            var values = _mapper.Map<Feature>(createfeatereDto);
            await _featureCollection.InsertOneAsync(values);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x=> x.FeatureId == id);
        }

        public async Task<List<ResultFeature>> GetAllFeatureAsync()
        {
            var values = await _featureCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeature>>(values);
        }

        public async Task<GetByFeature> GetByIdFeatureAsync(string id)
        {
            var values = await _featureCollection.Find<Feature>(x => x.FeatureId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByFeature>(values);
        }

        public Task UpdateFeatureAsync(UpdateFeature updatefeatureDto)
        {
            var values = _mapper.Map<Feature>(updatefeatureDto);
            return _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == updatefeatureDto.FeatureId, values);
        }
    }
}
