using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesionController : ControllerBase
    {
        private readonly IProfesionRepository _repo;

        public ProfesionController(IProfesionRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var profesion = await _repo.GetByIdAsync(id);
            return profesion == null ? NotFound() : Ok(profesion);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Profesion profesion)
        {
            var created = await _repo.AddAsync(profesion);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Profesion profesion)
        {
            var updated = await _repo.UpdateAsync(id, profesion);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
