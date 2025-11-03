using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Interfaces;

namespace personapi_dotnet.Controllers.Web
{
    public class TelefonoController : Controller
    {
        private readonly ITelefonoRepository _telefonoRepository;
        private readonly IPersonaRepository _personaRepository;

        public TelefonoController(
            ITelefonoRepository telefonoRepository,
            IPersonaRepository personaRepository)
        {
            _telefonoRepository = telefonoRepository;
            _personaRepository = personaRepository;
        }

        // GET: Telefono
        public async Task<IActionResult> Index()
        {
            var telefonos = await _telefonoRepository.GetAllAsync();
            return View(telefonos);
        }

        // GET: Telefono/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _telefonoRepository.GetByIdAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // GET: Telefono/Create
        public async Task<IActionResult> Create()
        {
            var personas = await _personaRepository.GetAllAsync();
            ViewData["Duenio"] = new SelectList(personas, "Cc", "Nombre");
            return View();
        }

        // POST: Telefono/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Num,Oper,Duenio")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                await _telefonoRepository.CreateAsync(telefono);
                return RedirectToAction(nameof(Index));
            }
            var personas = await _personaRepository.GetAllAsync();
            ViewData["Duenio"] = new SelectList(personas, "Cc", "Nombre", telefono.Duenio);
            return View(telefono);
        }

        // GET: Telefono/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _telefonoRepository.GetByIdAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }
            var personas = await _personaRepository.GetAllAsync();
            ViewData["Duenio"] = new SelectList(personas, "Cc", "Cc", telefono.Duenio);
            return View(telefono);
        }

        // POST: Telefono/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Num,Oper,Duenio")] Telefono telefono)
        {
            if (id != telefono.Num)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _telefonoRepository.UpdateAsync(telefono);
                }
                catch (Exception)
                {
                    if (!await TelefonoExists(telefono.Num))
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
            ViewData["Duenio"] = new SelectList(personas, "Cc", "Nombre", telefono.Duenio);
            return View(telefono);
        }

        // GET: Telefono/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _telefonoRepository.GetByIdAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        // POST: Telefono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _telefonoRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TelefonoExists(string id)
        {
            return await _telefonoRepository.GetByIdAsync(id) != null;
        }
    }
}
