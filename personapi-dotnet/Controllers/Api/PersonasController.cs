using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Interfaces;

namespace personapi_dotnet.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaRepository _repository;

        public PersonasController(IPersonaRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            var personas = await _repository.GetAllAsync();
            return Ok(personas);
        }

        // GET: api/Personas/5
        [HttpGet("{cc}")]
        public async Task<ActionResult<Persona>> GetPersona(int cc)
        {
            var persona = await _repository.GetByIdAsync(cc);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // PUT: api/Personas/5
        [HttpPut("{cc}")]
        public async Task<IActionResult> PutPersona(int cc, Persona persona)
        {
            if (cc != persona.Cc)
            {
                return BadRequest();
            }

            try
            {
                await _repository.UpdateAsync(persona);
            }
            catch (Exception)
            {
                if (!await PersonaExists(cc))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Personas
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            await _repository.CreateAsync(persona);
            return CreatedAtAction("GetPersona", new { cc = persona.Cc }, persona);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{cc}")]
        public async Task<IActionResult> DeletePersona(int cc)
        {
            var persona = await _repository.GetByIdAsync(cc);
            if (persona == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(cc);
            return NoContent();
        }

        // GET: api/Personas/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetPersonasCount()
        {
            var count = await _repository.GetCountAsync();
            return count;
        }

        private async Task<bool> PersonaExists(int cc)
        {
            return await _repository.GetByIdAsync(cc) != null;
        }
    }
}