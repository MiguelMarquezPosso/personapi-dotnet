using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Interfaces;

namespace personapi_dotnet.Controllers.Web
{
    public class EstudiosController : Controller
    {
        private readonly IEstudioRepository _estudioRepository;
        private readonly IPersonaRepository _personaRepository;
        private readonly IProfesionRepository _profesionRepository;

        public EstudiosController(
            IEstudioRepository estudioRepository,
            IPersonaRepository personaRepository,
            IProfesionRepository profesionRepository)
        {
            _estudioRepository = estudioRepository;
            _personaRepository = personaRepository;
            _profesionRepository = profesionRepository;
        }

        // GET: Estudios
        public async Task<IActionResult> Index()
        {
            var estudios = await _estudioRepository.GetAllAsync();
            return View(estudios);
        }

        // GET: Estudios/Details/5/1010
        public async Task<IActionResult> Details(int idProf, int ccPer)
        {
            var estudio = await _estudioRepository.GetByIdAsync(idProf, ccPer);
            if (estudio == null)
            {
                return NotFound();
            }

            return View(estudio);
        }

        // GET: Estudios/Create
        public async Task<IActionResult> Create()
        {
            var personas = await _personaRepository.GetAllAsync();
            var profesiones = await _profesionRepository.GetAllAsync();

            ViewData["CcPer"] = new SelectList(personas, "Cc", "Cc");
            ViewData["IdProf"] = new SelectList(profesiones, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProf,CcPer,Fecha,Univer")] Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                await _estudioRepository.CreateAsync(estudio);
                return RedirectToAction(nameof(Index));
            }

            var personas = await _personaRepository.GetAllAsync();
            var profesiones = await _profesionRepository.GetAllAsync();
            ViewData["CcPer"] = new SelectList(personas, "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(profesiones, "Id", "Id", estudio.IdProf);
            return View(estudio);
        }

        // GET: Estudios/Edit/5/1010
        public async Task<IActionResult> Edit(int idProf, int ccPer)
        {
            var estudio = await _estudioRepository.GetByIdAsync(idProf, ccPer);
            if (estudio == null)
            {
                return NotFound();
            }

            var personas = await _personaRepository.GetAllAsync();
            var profesiones = await _profesionRepository.GetAllAsync();
            ViewData["CcPer"] = new SelectList(personas, "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(profesiones, "Id", "Id", estudio.IdProf);
            return View(estudio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int idProf, int ccPer, [Bind("IdProf,CcPer,Fecha,Univer")] Estudio estudio)
        {
            if (idProf != estudio.IdProf || ccPer != estudio.CcPer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _estudioRepository.UpdateAsync(estudio);
                }
                catch (Exception)
                {
                    if (!await EstudioExists(estudio.IdProf, estudio.CcPer))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            var personas = await _personaRepository.GetAllAsync();
            var profesiones = await _profesionRepository.GetAllAsync();
            ViewData["CcPer"] = new SelectList(personas, "Cc", "Cc", estudio.CcPer);
            ViewData["IdProf"] = new SelectList(profesiones, "Id", "Id", estudio.IdProf);
            return View(estudio);
        }

        // GET: Estudios/Delete/5/1010
        public async Task<IActionResult> Delete(int idProf, int ccPer)
        {
            var estudio = await _estudioRepository.GetByIdAsync(idProf, ccPer);
            if (estudio == null)
            {
                return NotFound();
            }

            return View(estudio);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int idProf, int ccPer)
        {
            await _estudioRepository.DeleteAsync(idProf, ccPer);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EstudioExists(int idProf, int ccPer)
        {
            var estudio = await _estudioRepository.GetByIdAsync(idProf, ccPer);
            return estudio != null;
        }
    }
}