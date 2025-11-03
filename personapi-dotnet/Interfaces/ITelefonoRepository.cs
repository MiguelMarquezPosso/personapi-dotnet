using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface ITelefonoRepository
    {
        Task<IEnumerable<Telefono>> GetAllAsync();
        Task<Telefono?> GetByIdAsync(string num);
        Task<Telefono> CreateAsync(Telefono telefono);
        Task<Telefono> UpdateAsync(Telefono telefono);
        Task DeleteAsync(string num);
        Task<int> GetCountAsync();
    }
}