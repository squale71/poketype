using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

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

        [BsonElement("attackMatchups")]
        public IEnumerable<PokemonTypeModifier> AttackMatchups { get; set; }

        [BsonElement("defenseMatchups")]
        public IEnumerable<PokemonTypeModifier> DefenseMatchups { get; set; }

        [BsonElement("hexColor")]
        public string HexColor { get; set; }

        [BsonElement("displayName")]
        public string DisplayName { get; set; }
    }
}
