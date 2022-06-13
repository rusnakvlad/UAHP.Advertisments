using Advertisment.DAL.Enteties;

namespace Advertisment.DAL.IRepositories;

public interface IAdRepository : IGenericRepository<Ad>
{
    Task<Ad> InsertAndGetInserted(string storedProcedure, Ad advertisment, string connectionId = "Default");
}
