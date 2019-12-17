using Poketype.Service.Constants;

namespace Poketype.Service.DTOs
{
    public class PokemonTypeModifierDTO
    {
        public string Type { get; set; }

        public TypeModifier Modifier { get; set; }
    }
}
