using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace MongoDB.Driver.AspNetCore.MongoDB.Driver.AspNetCore
{
    public class MongoDbContext : IMongoDbContext
    {
        public IMongoClient Client { get; }
        public IMongoDatabase Database { get; }

        public MongoDbContext(string connectionString, string database)
        {
            Client = new MongoClient(connectionString);
            Database = Client.GetDatabase(database);
        }
        public MongoDbContext(string database, MongoClientSettings settings)
        {

            Client = new MongoClient(settings);
            Database = Client.GetDatabase(database);
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>()
        {
            return GetCollection<TDocument>(name: typeof(TDocument).Name);
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>(string name)
        {
            return Database.GetCollection<TDocument>(name);
        }
    }
}