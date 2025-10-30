using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Interfaces
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetAllAsync();
        Task<Persona?> GetByIdAsync(int cc);
        Task<Persona> AddAsync(Persona persona);
        Task<Persona?> UpdateAsync(int cc, Persona persona);
        Task<bool> DeleteAsync(int cc);
    }
}
