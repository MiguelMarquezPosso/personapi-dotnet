using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Interfaces
{
    public interface IProfesionRepository
    {
        Task<IEnumerable<Profesion>> GetAllAsync();
        Task<Profesion?> GetByIdAsync(int id);
        Task<Profesion> AddAsync(Profesion profesion);
        Task<Profesion?> UpdateAsync(int id, Profesion profesion);
        Task<bool> DeleteAsync(int id);
    }
}
