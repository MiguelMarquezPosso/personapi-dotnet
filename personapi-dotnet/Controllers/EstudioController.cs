using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudioController : ControllerBase
    {
        private readonly IEstudioRepository _repo;

        public EstudioController(IEstudioRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{idProf}/{ccPer}")]
        public async Task<IActionResult> GetById(int idProf, int ccPer)
        {
            var estudio = await _repo.GetByIdAsync(idProf, ccPer);
            return estudio == null ? NotFound() : Ok(estudio);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Estudio estudio)
        {
            var created = await _repo.AddAsync(estudio);
            return CreatedAtAction(nameof(GetById),
                new { idProf = created.IdProf, ccPer = created.CcPer }, created);
        }

        [HttpDelete("{idProf}/{ccPer}")]
        public async Task<IActionResult> Delete(int idProf, int ccPer)
        {
            var deleted = await _repo.DeleteAsync(idProf, ccPer);
            return deleted ? NoContent() : NotFound();
        }
    }
}
