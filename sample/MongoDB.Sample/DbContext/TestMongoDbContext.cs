using MongoDB.Driver;
using MongoDB.Driver.AspNetCore.MongoDB.Driver.AspNetCore;
using MongoDB.Sample.Documents;

namespace MongoDB.Sample.DbContext;

public class TestMongoDbContext : MongoDbContext
{
    public TestMongoDbContext(string connectionString, string database) : base(connectionString, database)
    {
    }

    public TestMongoDbContext(string database, MongoClientSettings settings) : base(database, settings)
    {
    }

    public IMongoCollection<Doc> Doc => GetCollection<Doc>(nameof(Doc));
}