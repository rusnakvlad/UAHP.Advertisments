using Advertisment.BLL.IServices;
using Advertisment.DAL.Enteties;
using Advertisment.DAL.UnitOfWork;

namespace Advertisment.BLL.Services;

public class AdTagService : IAdTagService
{
    private readonly IUnitOfWork unitOfWork;
    public AdTagService(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

    public async Task<IEnumerable<Tag>> GetAllByAdId(int advertismentId)
    {
        return await unitOfWork.TagRepository.GetByCriteriaAsync("GetTagsByAdId", new { advertismentId });
    }

    public async Task InsertAsync(AdTag adTag)
    {
        await unitOfWork.AdTagRepository.InsertAsync("InsertIntoAdTag", new { advertismentId = adTag.AdvertismentID, tagsTagName = adTag.TagName });
    }

    public async Task InsertRange(IEnumerable<AdTag> tags)
    {
        await unitOfWork.AdTagRepository.InsertRange<IEnumerable<AdTag>>("InsertIntoAdTag", tags);

    }
}
