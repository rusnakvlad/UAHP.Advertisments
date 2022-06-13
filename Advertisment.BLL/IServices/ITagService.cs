using Advertisment.DAL.Enteties;

namespace Advertisment.BLL.IServices;

public interface ITagService
{
    public Task InsertAsync(string TagName);
    public Task DeleteAsync(string TagName);
    public Task<IEnumerable<Tag>> GetAllAsync();
}
