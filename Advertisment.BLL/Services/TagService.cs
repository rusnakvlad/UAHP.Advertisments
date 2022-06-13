using Advertisment.BLL.IServices;
using Advertisment.DAL.Enteties;
using Advertisment.DAL.UnitOfWork;

namespace Advertisment.BLL.Services;

public class TagService : ITagService
{
    private readonly IUnitOfWork unitOfWork;
    public TagService(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

    public async Task DeleteAsync(string TagName)
    {
        await unitOfWork.TagRepository.DeleteAsync("DeleteTagByName", new { tagName = TagName });
    }

    public async Task<IEnumerable<Tag>> GetAllAsync()
    {
        return await unitOfWork.TagRepository.GetAllAsync("GetAllTags");
    }

    public async Task InsertAsync(string TagName)
    {
        await unitOfWork.TagRepository.InsertAsync("InsertTag", new { tagName = TagName });
    }
}
