using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Interfaces;

namespace personapi_dotnet.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesionesController : ControllerBase
    {
        private readonly IProfesionRepository _repository;

        public ProfesionesController(IProfesionRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Profesiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesion>>> GetProfesiones()
        {
            var profesiones = await _repository.GetAllAsync();
            return Ok(profesiones);
        }

        // GET: api/Profesiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesion>> GetProfesion(int id)
        {
            var profesion = await _repository.GetByIdAsync(id);

            if (profesion == null)
            {
                return NotFound();
            }

            return profesion;
        }

        // PUT: api/Profesiones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesion(int id, Profesion profesion)
        {
            if (id != profesion.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.UpdateAsync(profesion);
            }
            catch (Exception)
            {
                if (!await ProfesionExists(id))
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

        // POST: api/Profesiones
        [HttpPost]
        public async Task<ActionResult<Profesion>> PostProfesion(Profesion profesion)
        {
            await _repository.CreateAsync(profesion);
            return CreatedAtAction("GetProfesion", new { id = profesion.Id }, profesion);
        }

        // DELETE: api/Profesiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesion(int id)
        {
            var profesion = await _repository.GetByIdAsync(id);
            if (profesion == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);
            return NoContent();
        }

        // GET: api/Profesiones/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetProfesionesCount()
        {
            var count = await _repository.GetCountAsync();
            return count;
        }

        private async Task<bool> ProfesionExists(int id)
        {
            return await _repository.GetByIdAsync(id) != null;
        }
    }
}