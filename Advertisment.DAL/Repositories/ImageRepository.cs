using Advertisment.DAL.Enteties;
using Advertisment.DAL.IRepositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Advertisment.DAL.Repositories;

public class ImageRepository : GenericRepository<Image>, IImageRepository
{
    public ImageRepository(IConfiguration config) : base(config)
    {
    }

    public async Task InsertRange<U>(string storedProcedure, IEnumerable<Image> images, string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(config[$"ConnectionString:{connectionId}"]);
        foreach (var image in images)
        {
            await connection.ExecuteAsync(storedProcedure,
                new { advertismentId = image.AdvertismentId, imageFile = image.ImageFile },commandType: CommandType.StoredProcedure);
        }
    }
}
