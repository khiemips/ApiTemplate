using Common.Entity;
using Common.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace Repository
{
    public class DbContext
    {
        private readonly IMongoDatabase _database = null;

        public DbContext(IOptions<MongoDbSetting> settings)
        {
            var mongoClienSettings = MongoClientSettings.FromUrl(new MongoUrl(settings.Value.ConnectionString));

            var client = new MongoClient(mongoClienSettings);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }


        public IMongoCollection<T> Get<T>() where T : EntityBase
        {
            return _database.GetCollection<T>(typeof(T).Name);
        }
        
    }
}
