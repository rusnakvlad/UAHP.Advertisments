using Advertisment.DAL.Enteties;

namespace Advertisment.DAL.IRepositories;

public interface IImageRepository : IGenericRepository<Image>
{
    public Task InsertRange<U>(string storedProcedure, IEnumerable<Image> images, string connectionId = "Default");
}
