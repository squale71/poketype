using System.Collections.Generic;

namespace Poketype.Service.DTOs
{
    public class PokemonTypeDTO
    {
        public string Name { get; set; }

        public string Display { get; set; }

        public string HexColor { get; set; }

        public IEnumerable<PokemonTypeModifierDTO> AttackMatchups { get; set; }

        public IEnumerable<PokemonTypeModifierDTO> DefenseMatchups { get; set; }
    }
}
