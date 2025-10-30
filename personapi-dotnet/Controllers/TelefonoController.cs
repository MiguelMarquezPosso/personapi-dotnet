using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelefonoController : ControllerBase
    {
        private readonly ITelefonoRepository _repo;

        public TelefonoController(ITelefonoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{num}")]
        public async Task<IActionResult> GetById(string num)
        {
            var telefono = await _repo.GetByIdAsync(num);
            return telefono == null ? NotFound() : Ok(telefono);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Telefono telefono)
        {
            var created = await _repo.AddAsync(telefono);
            return CreatedAtAction(nameof(GetById), new { num = created.Num }, created);
        }

        [HttpPut("{num}")]
        public async Task<IActionResult> Update(string num, [FromBody] Telefono telefono)
        {
            var updated = await _repo.UpdateAsync(num, telefono);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{num}")]
        public async Task<IActionResult> Delete(string num)
        {
            var deleted = await _repo.DeleteAsync(num);
            return deleted ? NoContent() : NotFound();
        }
    }
}
