using personapi_dotnet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapi_dotnet.Interfaces
{
    public interface IEstudioRepository
    {
        Task<IEnumerable<Estudio>> GetAllAsync();
        Task<Estudio?> GetByIdAsync(int idProf, int ccPer);
        Task<Estudio> AddAsync(Estudio estudio);
        Task<bool> DeleteAsync(int idProf, int ccPer);
    }
}
