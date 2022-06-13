using Advertisment.BLL.IServices;
using Advertisment.DAL.Enteties;
using Advertisment.DAL.UnitOfWork;

namespace Advertisment.BLL.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork unitOfWork;
    public UserService(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

    public async Task DeleteByIdAsync(string id)
    {
        await unitOfWork.UserRepository.DeleteAsync("DeleteUserById", new { id });
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await unitOfWork.UserRepository.GetAllAsync("GetAllUsers");
    }

    public async Task<User> GetByIdAsync(string id)
    {
        return await unitOfWork.UserRepository.GetAsync("GetUserById", new { id });
    }

    public async Task InsertAsync(User user)
    {
        await unitOfWork.UserRepository.InsertAsync("InsertUser", user);
    }

    public async Task<User> UpdateAsync(User user)
    {
        await unitOfWork.UserRepository.UpdateAsync("UpdateUser", user);
        return await GetByIdAsync(user.Id);
    }
}
