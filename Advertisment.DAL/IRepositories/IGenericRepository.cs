
namespace Advertisment.DAL.IRepositories;
public interface IGenericRepository<TEntity>
{
    Task DeleteAsync<U>(string storedProcedure, U parameters, string connectionId = "Default");
    Task<IEnumerable<TEntity>> GetAllAsync(string storedProcedure, string connectionId = "Default");
    Task<TEntity> GetAsync<U>(string storedProcedure, U parameters, string connectionId = "Default");
    Task InsertAsync<U>(string storedProcedure, U parameters, string connectionId = "Default");
    Task UpdateAsync<U>(string storedProcedure, U parameters, string connectionId = "Default");
    Task<IEnumerable<TEntity>> GetByCriteriaAsync<U>(string storedProcedure, U parameters, string connectionId = "Default");
}
