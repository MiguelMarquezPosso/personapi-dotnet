using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface IProfesionRepository
    {
        Task<IEnumerable<Profesion>> GetAllAsync();
        Task<Profesion?> GetByIdAsync(int id);
        Task<Profesion> CreateAsync(Profesion profesion);
        Task<Profesion> UpdateAsync(Profesion profesion);
        Task DeleteAsync(int id);
        Task<int> GetCountAsync();
    }
}