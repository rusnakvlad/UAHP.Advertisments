using Advertisment.DAL.Enteties;
using Advertisment.DAL.IRepositories;
using Microsoft.Extensions.Configuration;

namespace Advertisment.DAL.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(IConfiguration config) : base(config)
    {
    }
}
