using Advertisment.DAL.Enteties;
using Advertisment.DAL.IRepositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Advertisment.DAL.Repositories;

public class AdRepository : GenericRepository<Ad>, IAdRepository
{
    public AdRepository(IConfiguration config) : base(config)
    {
    }

    public async Task<Ad> InsertAndGetInserted(string storedProcedure,Ad advertisment, string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(config[$"ConnectionString:{connectionId}"]);
        var result = await connection.QuerySingleAsync<Ad>(storedProcedure,
            new
            {
                userId = advertisment.UserId,
                price = advertisment.Price,
                region = advertisment.Region,
                city = advertisment.City,
                street = advertisment.Street,
                houseNumber = advertisment.HouseNumber,
                houseType = advertisment.HouseType,
                areaOfHouse = advertisment.AreaOfHouse,
                floorAmount = advertisment.FloorAmount,
                roomNumber = advertisment.RoomNumber,
                houseYear = advertisment.HouseYear,
                pool = advertisment.Pool,
                balkon = advertisment.Balkon,
                rentOportunity = advertisment.RentOportunity,
                description = advertisment.Description
            }
            , commandType: CommandType.StoredProcedure); ;
        return result;
    }
}
