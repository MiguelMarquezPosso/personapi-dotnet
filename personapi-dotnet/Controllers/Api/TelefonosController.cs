using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models;
using personapi_dotnet.Interfaces;

namespace personapi_dotnet.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelefonosController : ControllerBase
    {
        private readonly ITelefonoRepository _repository;

        public TelefonosController(ITelefonoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Telefonos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telefono>>> GetTelefonos()
        {
            var telefonos = await _repository.GetAllAsync();
            return Ok(telefonos);
        }

        // GET: api/Telefonos/5
        [HttpGet("{num}")]
        public async Task<ActionResult<Telefono>> GetTelefono(string num)
        {
            var telefono = await _repository.GetByIdAsync(num);

            if (telefono == null)
            {
                return NotFound();
            }

            return telefono;
        }

        // PUT: api/Telefonos/5
        [HttpPut("{num}")]
        public async Task<IActionResult> PutTelefono(string num, Telefono telefono)
        {
            if (num != telefono.Num)
            {
                return BadRequest();
            }

            try
            {
                await _repository.UpdateAsync(telefono);
            }
            catch (Exception)
            {
                if (!await TelefonoExists(num))
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

        // POST: api/Telefonos
        [HttpPost]
        public async Task<ActionResult<Telefono>> PostTelefono(Telefono telefono)
        {
            await _repository.CreateAsync(telefono);
            return CreatedAtAction("GetTelefono", new { num = telefono.Num }, telefono);
        }

        // DELETE: api/Telefonos/5
        [HttpDelete("{num}")]
        public async Task<IActionResult> DeleteTelefono(string num)
        {
            var telefono = await _repository.GetByIdAsync(num);
            if (telefono == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(num);
            return NoContent();
        }

        // GET: api/Telefonos/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetTelefonosCount()
        {
            var count = await _repository.GetCountAsync();
            return count;
        }

        private async Task<bool> TelefonoExists(string num)
        {
            return await _repository.GetByIdAsync(num) != null;
        }
    }
}