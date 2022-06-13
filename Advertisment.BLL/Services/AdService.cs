using Advertisment.BLL.DTO;
using Advertisment.BLL.IServices;
using Advertisment.DAL.Enteties;
using Advertisment.DAL.UnitOfWork;
using AutoMapper;

namespace Advertisment.BLL.Services;

public class AdService : IAdService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IImageService imageService;
    private readonly IAdTagService adTagService;

    public AdService(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService, IAdTagService adTagService)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.imageService = imageService;
        this.adTagService = adTagService;
    }
    public async Task DeleteByIdAsync(int id)
    {
        await unitOfWork.AdRepository.DeleteAsync("DeleteAdById", new { id });
    }

    public async Task<AdDTO> GetByIdAsync(int id)
    {
        var entity = await unitOfWork.AdRepository.GetAsync("GetAdvertismentById", new { id });
        var images = await imageService.GetImagesByAdId(entity.Id);
        var tags = await adTagService.GetAllByAdId(entity.Id);
        var mappedAdvertisment = mapper.Map<AdDTO>((entity, images, tags));
        return mappedAdvertisment;
    }

    public async Task<Ad> InsertAsync(AdCreateDTO model)
    {
        var adEntity = mapper.Map<Ad>(model);
        var addedEntity = await unitOfWork.AdRepository.InsertAndGetInserted("InsertAndGetInsertedAdvertisment", adEntity);

        if (!model.Images.All(x => x.ImageFile.Length == 0))
        {
            var images = mapper.Map<IEnumerable<Image>>((model, addedEntity.Id));
            await InsertAdvertismentsImages(images);
        }
        if (model.Tags.Any())
        {
            var tags = mapper.Map<IEnumerable<AdTag>>((model, addedEntity.Id));
            await InsertAdvertismentsTags(tags);
        }

        return addedEntity;
    }

    public async Task<AdDTO> UpdateAsync(Ad model)
    {
        await unitOfWork.AdRepository.UpdateAsync("UpdateAdvertisment", model);
        return await GetByIdAsync(model.Id);
    }

    private async Task InsertAdvertismentsImages(IEnumerable<Image> images)
    => await imageService.InsertRange(images);

    private async Task InsertAdvertismentsTags(IEnumerable<AdTag> tags)
    => await adTagService.InsertRange(tags);
}
