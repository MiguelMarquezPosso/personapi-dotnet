using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Repositories
{
    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly PersonaDbContext _context;

        public TelefonoRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Telefono>> GetAllAsync() =>
            await _context.Telefonos.Include(t => t.DuenioNavigation).ToListAsync();

        public async Task<Telefono?> GetByIdAsync(string num) =>
            await _context.Telefonos.Include(t => t.DuenioNavigation).FirstOrDefaultAsync(t => t.Num == num);

        public async Task<Telefono> AddAsync(Telefono telefono)
        {
            _context.Telefonos.Add(telefono);
            await _context.SaveChangesAsync();
            return telefono;
        }

        public async Task<Telefono?> UpdateAsync(string num, Telefono telefono)
        {
            var existing = await _context.Telefonos.FindAsync(num);
            if (existing == null) return null;

            existing.Oper = telefono.Oper;
            existing.Duenio = telefono.Duenio;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(string num)
        {
            var telefono = await _context.Telefonos.FindAsync(num);
            if (telefono == null) return false;

            _context.Telefonos.Remove(telefono);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
