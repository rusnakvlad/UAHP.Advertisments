using Advertisment.DAL.IRepositories;

namespace Advertisment.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IUserRepository userRepository, IAdRepository adRepository,
        ITagRepository tagRepository, IImageRepository imageRepository, IAdTagRepository adTagRepository)
    {
        UserRepository = userRepository;
        AdRepository = adRepository;
        TagRepository = tagRepository;
        ImageRepository = imageRepository;
        AdTagRepository = adTagRepository;
    }
    public IUserRepository UserRepository { get; }
    public IAdRepository AdRepository { get; }
    public ITagRepository TagRepository { get; }
    public IImageRepository ImageRepository { get; }
    public IAdTagRepository AdTagRepository { get; }
}
