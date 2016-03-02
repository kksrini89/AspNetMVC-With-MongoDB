using MongoDB.Bson;
using MongoDB.Driver;
using SampleAspNetMVC_MongoDB.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAspNetMVC_MongoDB.Models
{
    public class MongoDBContext
    {
        private IMongoClient Client;
        private IMongoDatabase Database;
        public MongoDBContext()
        {
            Client = new MongoClient(Settings.Default.SampleConnectionString);
            Database = Client.GetDatabase(Settings.Default.DataBaseName);
        }

        public IMongoCollection<Car> Cars
        {
            get
            {
                return Database.GetCollection<Car>("car");
            }
        }
    }
}