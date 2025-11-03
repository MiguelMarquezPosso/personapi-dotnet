using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models;
using personapi_dotnet.Interfaces;

namespace personapi_dotnet.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiosController : ControllerBase
    {
        private readonly IEstudioRepository _repository;

        public EstudiosController(IEstudioRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Estudios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudio>>> GetEstudios()
        {
            var estudios = await _repository.GetAllAsync();
            return Ok(estudios);
        }

        // GET: api/Estudios/5/1010
        [HttpGet("{idProf}/{ccPer}")]
        public async Task<ActionResult<Estudio>> GetEstudio(int idProf, int ccPer)
        {
            var estudio = await _repository.GetByIdAsync(idProf, ccPer);

            if (estudio == null)
            {
                return NotFound();
            }

            return estudio;
        }

        // PUT: api/Estudios/5/1010
        [HttpPut("{idProf}/{ccPer}")]
        public async Task<IActionResult> PutEstudio(int idProf, int ccPer, Estudio estudio)
        {
            if (idProf != estudio.IdProf || ccPer != estudio.CcPer)
            {
                return BadRequest();
            }

            try
            {
                await _repository.UpdateAsync(estudio);
            }
            catch (Exception)
            {
                if (!await EstudioExists(idProf, ccPer))
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

        // POST: api/Estudios
        [HttpPost]
        public async Task<ActionResult<Estudio>> PostEstudio(Estudio estudio)
        {
            await _repository.CreateAsync(estudio);
            return CreatedAtAction("GetEstudio", new { idProf = estudio.IdProf, ccPer = estudio.CcPer }, estudio);
        }

        // DELETE: api/Estudios/5/1010
        [HttpDelete("{idProf}/{ccPer}")]
        public async Task<IActionResult> DeleteEstudio(int idProf, int ccPer)
        {
            var estudio = await _repository.GetByIdAsync(idProf, ccPer);
            if (estudio == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(idProf, ccPer);
            return NoContent();
        }

        // GET: api/Estudios/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetEstudiosCount()
        {
            var count = await _repository.GetCountAsync();
            return count;
        }

        private async Task<bool> EstudioExists(int idProf, int ccPer)
        {
            return await _repository.GetByIdAsync(idProf, ccPer) != null;
        }
    }
}