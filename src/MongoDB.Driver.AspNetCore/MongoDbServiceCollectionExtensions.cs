using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver.AspNetCore.MongoDB.Driver.AspNetCore;
using System;
using System.Runtime;

namespace MongoDB.Driver.AspNetCore
{
    public static class MongoDbServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDbContext<TMongoDbContext>(this IServiceCollection services, string connectionString,
            string database) where TMongoDbContext : MongoDbContext
        {
            services.AddSingleton(sp =>
            {
                var type = typeof(TMongoDbContext);
                return Activator.CreateInstance(type, connectionString, database) as TMongoDbContext;
            });

            services.AddMongoDbContext(connectionString, database);

            return services;
        }

        public static IServiceCollection AddMongoDbContext<TMongoDbContext>(this IServiceCollection services, string connectionString,
            string database, Action<MongoClientSettings> options) where TMongoDbContext : MongoDbContext
        {
            var settings = MongoClientSettings.FromConnectionString(connectionString);

            options.Invoke(settings);

            services.AddSingleton(sp =>
            {
                var type = typeof(TMongoDbContext);
                return Activator.CreateInstance(type, database, settings) as TMongoDbContext;
            });

            services.AddMongoDbContext(database, settings);

            return services;
        }

        private static IServiceCollection AddMongoDbContext(this IServiceCollection services, string database, MongoClientSettings options)
        {
            services.AddSingleton(sp =>
            {
                return new MongoDbContext(database, options);
            });
            return services;
        }
        private static IServiceCollection AddMongoDbContext(this IServiceCollection services, string connectionString, string database)
        {
            services.AddSingleton(sp =>
            {
                return new MongoDbContext(connectionString, database);
            });
            return services;
        }
    }
}