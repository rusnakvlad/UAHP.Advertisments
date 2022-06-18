using Advertisment.BLL.DTO;
using Advertisment.DAL.Enteties;

namespace Advertisment.BLL.IServices;

public interface IAdService
{
    Task<AdDTO> GetByIdAsync(int id);
    Task DeleteByIdAsync(int id);
    Task<AdDTO> UpdateAsync(Ad model);
    Task<AdDTO> InsertAsync(AdCreateDTO model);
}
