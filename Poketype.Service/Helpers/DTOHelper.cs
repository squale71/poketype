using Poketype.Service.Data.Models;
using Poketype.Service.DTOs;
using System.Linq;

namespace Poketype.Service.Helpers
{
    public static class DTOHelper
    {
        public static PokemonTypeDTO GetPokemonTypeDTO(PokemonType type)
        {
            return new PokemonTypeDTO
            {
                Name = type.Name,
                Display = type.DisplayName,
                HexColor = type.HexColor,
                AttackMatchups = type.AttackMatchups.Select(x => new PokemonTypeModifierDTO
                {
                    Modifier = x.Modifier,
                    Type = x.Type
                }),
                DefenseMatchups = type.DefenseMatchups.Select(x => new PokemonTypeModifierDTO
                {
                    Modifier = x.Modifier,
                    Type = x.Type
                })
            };
        }
    }
}
