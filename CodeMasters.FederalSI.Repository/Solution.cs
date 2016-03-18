using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeMasters.FederalSI.Repository.Model
{
    [BsonIgnoreExtraElements]
    public class Solution
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("overview")]
        public string Overview { get; set; }

        private IMongoDatabase Database { get; set; }

        public Solution()
        {
            var db = new DbBase();
            Database = db.Database;
        }

        public IList<Solution> GetAllSolutions()
        {
            var mylist = Database.GetCollection<Solution>("solutions");

            return mylist.Find(x => true).ToList();
        }

        public Solution FindSolutionByName(string name)
        {
            return Database.GetCollection<Solution>("solutions").Find(x => x.Name == name).FirstOrDefault();
        }

        public Solution FindSolutionById(string id)
        {
            return Database.GetCollection<Solution>("solutions").Find(x => x.Id == id).FirstOrDefault();
        }

        public void UpdateSolutionById(Solution updatedSolution)
        {
            var mysolution = FindSolutionById(updatedSolution.Id);

            if (mysolution != null)
            {
                var filter = Builders<Solution>.Filter.Eq(y => y.Id, updatedSolution.Id);
                Database.GetCollection<Solution>("solutions").ReplaceOne(filter, updatedSolution);
            }
        }
    }
}
