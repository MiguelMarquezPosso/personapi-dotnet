using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetAllAsync();
        Task<Persona?> GetByIdAsync(int cc);
        Task<Persona> CreateAsync(Persona persona);
        Task<Persona> UpdateAsync(Persona persona);
        Task DeleteAsync(int cc);
        Task<int> GetCountAsync();
    }
}