using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MongoDB.Driver.GridFS;


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

        //public List<Document>


        private IMongoDatabase Database { get; set; }

        private IGridFSBucket _bucket;
        public IGridFSBucket Bucket
        {
            get
            {
                return new GridFSBucket(Database);
            }
        }

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

        public Stream GetFileByTitle(string solution, string filetitle)
        {
            //var filter = Builders<GridFSFileInfo>.Filter.Eq(u => u.Filename, "C:\\users\\nmadhusudan\\downloads\\127-b.pdf");
            var filter = Builders<GridFSFileInfo>.Filter.Eq("metadata:Title", solution +' '+ filetitle);
            var file = Bucket.Find(filter).ToList().FirstOrDefault();
            if (file != null)
            {
                var stream = Bucket.OpenDownloadStream(file.Id);

                return stream;
            }
            else
            {
                return null;
            }
            
        }
    }
}
