using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface IEstudioRepository
    {
        Task<IEnumerable<Estudio>> GetAllAsync();
        Task<Estudio?> GetByIdAsync(int idProf, int ccPer);
        Task<Estudio> CreateAsync(Estudio estudio);
        Task<Estudio> UpdateAsync(Estudio estudio);
        Task DeleteAsync(int idProf, int ccPer);
        Task<int> GetCountAsync();
    }
}