using Advertisment.DAL.Enteties;

namespace Advertisment.DAL.IRepositories;

public interface IAdTagRepository : IGenericRepository<AdTag>
{
    public Task InsertRange<U>(string storedProcedure, IEnumerable<AdTag> tags, string connectionId = "Default");

}
