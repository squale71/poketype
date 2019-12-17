using Microsoft.AspNetCore.Mvc;
using Poketype.Service.Data.Models;
using Poketype.Service.Repositories;
using System.Collections.Generic;

namespace Poketype.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly TypeRepository _typeRepository;

        public TypeController(TypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        [HttpGet]
        public ActionResult<List<PokemonType>> Get() => _typeRepository.Get();
    }
}