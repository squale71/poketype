using Poketype.Service.Data.Models;
using Poketype.Service.DTOs;

namespace Poketype.Service.Helpers
{
    public static class DTOHelper
    {
        public static PokemonTypeDTO GetPokemonTypeDTO(PokemonType type)
        {
            return new PokemonTypeDTO
            {
                Name = type.Name
            };
        }
    }
}
