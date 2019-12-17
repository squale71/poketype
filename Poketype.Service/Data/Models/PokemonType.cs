using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Poketype.Service.Data.Models
{
    public class PokemonType
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }
    }
}
