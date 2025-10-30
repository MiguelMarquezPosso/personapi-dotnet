using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepository _repo;

        public PersonaController(IPersonaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{cc}")]
        public async Task<IActionResult> GetById(int cc)
        {
            var persona = await _repo.GetByIdAsync(cc);
            return persona == null ? NotFound() : Ok(persona);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Persona persona)
        {
            var created = await _repo.AddAsync(persona);
            return CreatedAtAction(nameof(GetById), new { cc = created.Cc }, created);
        }

        [HttpPut("{cc}")]
        public async Task<IActionResult> Update(int cc, [FromBody] Persona persona)
        {
            var updated = await _repo.UpdateAsync(cc, persona);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{cc}")]
        public async Task<IActionResult> Delete(int cc)
        {
            var deleted = await _repo.DeleteAsync(cc);
            return deleted ? NoContent() : NotFound();
        }
    }
}
