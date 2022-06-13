using Advertisment.DAL.Enteties;

namespace Advertisment.BLL.IServices;

public interface IUserService
{
    Task DeleteByIdAsync(string id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(string id);
    Task InsertAsync(User user);
    Task<User> UpdateAsync(User user);
}
