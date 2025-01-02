using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        public IMapper _mapper;
        public readonly IMongoCollection<FeatureSlider> _featureSliderCollection;

        public FeatureSliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeautureSliderAsync(CreateFeatureSlider createfeauteSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(createfeauteSliderDto);
            await _featureSliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderId == id);
        }

        public async Task FeatureSliderChageStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public async Task FeatureSliderChageStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSlider>> GetAllFeautureSliderAsync()
        {
            var values = await _featureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSlider>>(values);
        }

        public async Task<GetByFeautureSlider> GetByIdFeatureSliderAsync(string id)
        {
            var values = await _featureSliderCollection.Find<FeatureSlider>(x => x.FeatureSliderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByFeautureSlider>(values);
        }

        public async Task UpdateFeautureSliderAsync(UpdateFeatureSlider updatefeautureSliderDto)
        {
            var values = _mapper.Map<FeatureSlider>(updatefeautureSliderDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == updatefeautureSliderDto.FeatureSliderId, values);
        }
    }
}
