using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Driver.AspNetCore.MongoDB.Driver.AspNetCore
{
    public interface IMongoDbContext
    {
        IMongoClient Client { get; }
        IMongoDatabase Database { get; }
        IMongoCollection<TDocument> GetCollection<TDocument>(string name);
        void DropCollection(string name);
    }
}