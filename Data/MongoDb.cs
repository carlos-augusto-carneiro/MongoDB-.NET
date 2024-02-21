using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMongoDB.Data.Collections;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace ApiMongoDB.Data
{
    public class MongoDb
    {
        public IMongoDatabase DB { get; }
        public MongoDb(IConfiguration configuration)
        {
            var setting = MongoClientSettings.FromUrl(new MongoUrl(configuration["mongodb"]));
            var client = new MongoClient(setting);
            DB = client.GetDatabase(configuration["NomeBanco"]);
            MapClasses();
        }

        private void MapClasses()
        {
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            if(!BsonClassMap.IsClassMapRegistered(typeof(Infectados)))
            {
                BsonClassMap.RegisterClassMap<Infectados>( i =>
                {
                    i.AutoMap();
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}