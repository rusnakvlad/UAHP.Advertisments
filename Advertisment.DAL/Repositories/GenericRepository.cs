using Advertisment.DAL.IRepositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Advertisment.DAL.Repositories;
public class GenericRepository<TEntity> : IGenericRepository<TEntity>
{
    protected readonly IConfiguration config;
    public GenericRepository(IConfiguration config)
    {
        this.config = config;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(string storedProcedure, string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(config[$"ConnectionString:{connectionId}"]);
        var result = await connection.QueryAsync<TEntity>(storedProcedure, commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task<TEntity> GetAsync<U>(string storedProcedure, U parameters, string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(config[$"ConnectionString:{connectionId}"]);
        return await connection.QueryFirstOrDefaultAsync<TEntity>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task InsertAsync<U>(string storedProcedure, U parameters, string connectionId = "Default")
    {
        await EditData<U>(storedProcedure, parameters, connectionId);
    }

    public async Task DeleteAsync<U>(string storedProcedure, U parameters, string connectionId = "Default")
    {
        await EditData<U>(storedProcedure, parameters, connectionId);
    }

    public async Task UpdateAsync<U>(string storedProcedure, U parameters, string connectionId = "Default")
    {
        await EditData(storedProcedure, parameters, connectionId);
    }

    private async Task EditData<U>(string storedProcedure, U parameters, string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(config[$"ConnectionString:{connectionId}"]);
        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<TEntity>> GetByCriteriaAsync<U>(string storedProcedure, U parameters, string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(config[$"ConnectionString:{connectionId}"]);
        var result = await connection.QueryAsync<TEntity>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        return result;
    }
}
