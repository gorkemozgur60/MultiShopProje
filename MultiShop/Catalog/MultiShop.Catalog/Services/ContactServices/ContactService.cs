using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Contact> _contactCollection;

        public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
            _mapper = mapper;

        }

        public async Task CreateContactAsync(CreateContactDto createcategoryDto)
        {
            var value = _mapper.Map<Contact>(createcategoryDto);
            await _contactCollection.InsertOneAsync(value);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(x => x.ContactId == id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _contactCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task<GetByContactDto> GetByIdContactAsync(string id) 
        {
            var values = await _contactCollection.Find<Contact>(x => x.ContactId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByContactDto>(values);
        }

        public async Task UpdateContactAsync(UpdateContactDto updatecategoryDto)
        {
            var values = _mapper.Map<Contact>(updatecategoryDto);
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == updatecategoryDto.ContactId, values);
        }
    }
}
