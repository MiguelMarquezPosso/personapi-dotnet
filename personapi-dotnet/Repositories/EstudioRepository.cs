using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly PersonaDbContext _context;

        public EstudioRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudio>> GetAllAsync() =>
            await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .ToListAsync();

        public async Task<Estudio?> GetByIdAsync(int idProf, int ccPer) =>
            await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefaultAsync(e => e.IdProf == idProf && e.CcPer == ccPer);

        public async Task<Estudio> AddAsync(Estudio estudio)
        {
            _context.Estudios.Add(estudio);
            await _context.SaveChangesAsync();
            return estudio;
        }

        public async Task<bool> DeleteAsync(int idProf, int ccPer)
        {
            var estudio = await _context.Estudios.FindAsync(idProf, ccPer);
            if (estudio == null) return false;

            _context.Estudios.Remove(estudio);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
