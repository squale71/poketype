using MongoDB.Driver;
using Poketype.Service.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Poketype.Service.Repositories
{
    public class PokemonTypeRepository
    {
        private readonly IMongoCollection<PokemonType> _types;

        public PokemonTypeRepository(IPoketypeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _types = database.GetCollection<PokemonType>(settings.TypesCollectionName);
        }

        public List<PokemonType> Get() =>
            _types.Find(book => true).ToList();

        public PokemonType Get(string name) =>
            _types.Find(type => type.Name == name).FirstOrDefault();

        public PokemonType Create(PokemonType type)
        {
            _types.InsertOne(type);
            return type;
        }

        public void Update(string name, PokemonType typeIn) =>
            _types.ReplaceOne(type => type.Name == name, typeIn);

        public void Remove(PokemonType typeIn) =>
            _types.DeleteOne(type => type.Name == typeIn.Name);

        public void Remove(string id) =>
            _types.DeleteOne(type => type.Name == id);
    }
}
