using Microsoft.AspNetCore.Mvc;
using Poketype.Service.DTOs;
using Poketype.Service.Helpers;
using Poketype.Service.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Poketype.Service.Controllers
{
    [Route("api/type")]
    [ApiController]
    public class PokemonTypeController : ControllerBase
    {
        private readonly PokemonTypeRepository _repository;

        public PokemonTypeController(PokemonTypeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<PokemonTypeDTO> Get(string name)
        {
            var data = _repository.Get(name);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(DTOHelper.GetPokemonTypeDTO(data));
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<PokemonTypeDTO>> GetAll()
        {
            var data = _repository.Get();

            return Ok(data.Select(x => DTOHelper.GetPokemonTypeDTO(x)));
        }
    }
}