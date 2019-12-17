using MongoDB.Bson.Serialization.Attributes;
using Poketype.Service.Constants;

namespace Poketype.Service.Data.Models
{
    public class PokemonTypeModifier
    {
        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("modifier")]
        public TypeModifier Modifier { get; set; }
    }
}
