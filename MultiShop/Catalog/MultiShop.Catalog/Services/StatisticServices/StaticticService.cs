
using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices
{
    public class StaticticService : IStaticticService
    {
        private IMongoCollection<Brand> _brandMongoCollection;
        private IMongoCollection<Category> _categoryMongoCollection;
        private IMongoCollection<Product> _productMongoCollection;

        public StaticticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _brandMongoCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
            _categoryMongoCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _productMongoCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        }

        public async Task<long> GetBrandCount()
        {
            return await _brandMongoCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
        }

        public async Task<long> GetCategoryCount()
        {
            return await _categoryMongoCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x=>x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y=>
                                                  y.ProductName).Exclude("ProductId");
            var product = await _productMongoCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y =>
                                                  y.ProductName).Exclude("ProductId");
            var product = await _productMongoCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;

        }

        public async Task<decimal> GetProductAvgCount()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$group",new BsonDocument
                {
                    {"_id",1 },
                    {"averagePrice" , new BsonDocument("$avg","$ProductPrice") }
                })
            };
            var result = await _productMongoCollection.AggregateAsync<BsonDocument>(pipeline);
            var price = result.FirstOrDefault().GetValue("averagePrice", decimal.Zero).AsDecimal;
            return price;
        }

        public async Task<long> GetProductCount()
        {
            return await _productMongoCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
    }
}
