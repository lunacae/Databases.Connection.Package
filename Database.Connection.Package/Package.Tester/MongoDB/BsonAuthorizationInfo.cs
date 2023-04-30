using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Package.Tester.MongoDB
{
    public class BsonClientAuthorization
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
