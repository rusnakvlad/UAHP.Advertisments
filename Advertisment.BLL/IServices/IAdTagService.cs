using Advertisment.DAL.Enteties;

namespace Advertisment.BLL.IServices;

public interface IAdTagService
{
    public Task InsertAsync(AdTag adTag);
    public Task InsertRange(IEnumerable<AdTag> tags);
    public Task<IEnumerable<Tag>> GetAllByAdId(int advertismentId);

}
