using Advertisment.DAL.Enteties;
using Advertisment.DAL.IRepositories;
using Microsoft.Extensions.Configuration;

namespace Advertisment.DAL.Repositories;

public class TagRepository : GenericRepository<Tag>, ITagRepository
{
    public TagRepository(IConfiguration config) : base(config)
    {
    }
}
