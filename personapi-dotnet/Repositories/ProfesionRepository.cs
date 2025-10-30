using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Repositories
{
    public class ProfesionRepository : IProfesionRepository
    {
        private readonly PersonaDbContext _context;

        public ProfesionRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profesion>> GetAllAsync() =>
            await _context.Profesions.Include(p => p.Estudios).ToListAsync();

        public async Task<Profesion?> GetByIdAsync(int id) =>
            await _context.Profesions.Include(p => p.Estudios).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Profesion> AddAsync(Profesion profesion)
        {
            _context.Profesions.Add(profesion);
            await _context.SaveChangesAsync();
            return profesion;
        }

        public async Task<Profesion?> UpdateAsync(int id, Profesion profesion)
        {
            var existing = await _context.Profesions.FindAsync(id);
            if (existing == null) return null;

            existing.Nom = profesion.Nom;
            existing.Des = profesion.Des;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var profesion = await _context.Profesions.FindAsync(id);
            if (profesion == null) return false;

            _context.Profesions.Remove(profesion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
