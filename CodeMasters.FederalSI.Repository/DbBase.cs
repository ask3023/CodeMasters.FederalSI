using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CodeMasters.FederalSI.Repository.Model
{
    public class DbBase
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        public IMongoDatabase Database { get; set; }

        public DbBase()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("FederalSI");
            Database = _database;
        }
    }
}
