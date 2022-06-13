using Advertisment.DAL.IRepositories;

namespace Advertisment.DAL.UnitOfWork;

public interface IUnitOfWork
{
    public IUserRepository UserRepository { get; }
    public IAdRepository AdRepository { get; }
    public ITagRepository TagRepository { get; }
    public IImageRepository ImageRepository { get; }
    IAdTagRepository AdTagRepository { get; }
}
