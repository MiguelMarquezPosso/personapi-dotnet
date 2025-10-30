using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Interfaces
{
    public interface ITelefonoRepository
    {
        Task<IEnumerable<Telefono>> GetAllAsync();
        Task<Telefono?> GetByIdAsync(string num);
        Task<Telefono> AddAsync(Telefono telefono);
        Task<Telefono?> UpdateAsync(string num, Telefono telefono);
        Task<bool> DeleteAsync(string num);
    }
}
