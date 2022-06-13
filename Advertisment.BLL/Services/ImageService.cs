using Advertisment.BLL.IServices;
using Advertisment.DAL.Enteties;
using Advertisment.DAL.UnitOfWork;
using Dapper;

namespace Advertisment.BLL.Services;

public class ImageService : IImageService
{
    private readonly IUnitOfWork unitOfWork;
    public ImageService(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

    public async Task DeleteById(int Id)
    {
        await unitOfWork.ImageRepository.DeleteAsync("DeleteImageById", new { id = Id });
    }

    public async Task<IEnumerable<Image>> GetImagesByAdId(int advertismentId)
    {
        return await unitOfWork.ImageRepository.GetByCriteriaAsync("GetImagesByAdId", new { advertismentId });
    }

    public async Task InsertImageAsync(Image image)
    {
        await unitOfWork.ImageRepository.InsertAsync("InsertImage", image);
    }

    public async Task InsertRange(IEnumerable<Image> images)
    {
        await unitOfWork.ImageRepository.InsertRange<IEnumerable<Image>>("InsertImage", images);
    }
}
