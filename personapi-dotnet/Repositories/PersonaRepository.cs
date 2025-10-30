using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonaDbContext _context;

        public PersonaRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas
                                 .Include(p => p.Telefonos)
                                 .Include(p => p.Estudios)
                                 .ToListAsync();
        }

        public async Task<Persona?> GetByIdAsync(int cc)
        {
            return await _context.Personas
                                 .Include(p => p.Telefonos)
                                 .Include(p => p.Estudios)
                                 .FirstOrDefaultAsync(p => p.Cc == cc);
        }

        public async Task<Persona> AddAsync(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        public async Task<Persona?> UpdateAsync(int cc, Persona persona)
        {
            var existing = await _context.Personas.FindAsync(cc);
            if (existing == null) return null;

            existing.Nombre = persona.Nombre;
            existing.Apellido = persona.Apellido;
            existing.Genero = persona.Genero;
            existing.Edad = persona.Edad;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int cc)
        {
            var persona = await _context.Personas.FindAsync(cc);
            if (persona == null) return false;

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
