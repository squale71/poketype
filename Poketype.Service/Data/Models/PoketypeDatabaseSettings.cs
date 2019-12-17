namespace Poketype.Service.Data.Models
{
    public class PoketypeDatabaseSettings : IPoketypeDatabaseSettings
    {
        public string TypesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPoketypeDatabaseSettings
    {
        string TypesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
