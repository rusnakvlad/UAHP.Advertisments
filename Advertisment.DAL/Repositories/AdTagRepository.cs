using Advertisment.DAL.Enteties;
using Advertisment.DAL.IRepositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Advertisment.DAL.Repositories;

public class AdTagRepository : GenericRepository<AdTag>, IAdTagRepository
{
    public AdTagRepository(IConfiguration config) : base(config)
    {
    }

    public async Task InsertRange<U>(string storedProcedure, IEnumerable<AdTag> tags, string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(config[$"ConnectionString:{connectionId}"]);
        foreach (var tag in tags)
        {
            await connection.ExecuteAsync(storedProcedure,
                new { advertismentId = tag.AdvertismentID, tagsTagName = tag.TagName }, commandType: CommandType.StoredProcedure);
        }
    }
}
