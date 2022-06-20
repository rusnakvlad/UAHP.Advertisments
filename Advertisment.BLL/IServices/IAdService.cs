using Advertisment.BLL.DTO;
using Advertisment.DAL.Enteties;

namespace Advertisment.BLL.IServices;

public interface IAdService
{
    Task<AdFullInfoDTO> GetByIdAsync(int id);
    Task DeleteByIdAsync(int id);
    Task<AdFullInfoDTO> UpdateAsync(Ad model);
    Task<AdFullInfoDTO> InsertAsync(AdCreateDTO model);
}
