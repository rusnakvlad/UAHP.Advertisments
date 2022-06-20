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
    private readonly IUserService userService;

    public AdService(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService, IAdTagService adTagService, IUserService userService)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.imageService = imageService;
        this.adTagService = adTagService;
        this.userService = userService;
    }
    public async Task DeleteByIdAsync(int id)
    {
        await unitOfWork.AdRepository.DeleteAsync("DeleteAdById", new { id });
    }

    public async Task<AdFullInfoDTO> GetByIdAsync(int id)
    {
        var entity = await unitOfWork.AdRepository.GetAsync("GetAdvertismentById", new { id });
        var images = await imageService.GetImagesByAdId(entity.Id);
        var tags = await adTagService.GetAllByAdId(entity.Id);
        var mappedAdvertisment = mapper.Map<AdFullInfoDTO>((entity, images, tags));
        var adOwner = await userService.GetByIdAsync(mappedAdvertisment.UserId);
        mappedAdvertisment.OwnerName = adOwner.Name;
        mappedAdvertisment.OwnerSurname = adOwner.Surname;
        mappedAdvertisment.OwnerEmail = adOwner.Email;
        mappedAdvertisment.OwnerPhone = adOwner.Phone;

        return mappedAdvertisment;
    }

    public async Task<AdFullInfoDTO> InsertAsync(AdCreateDTO model)
    {
        var adEntity = mapper.Map<Ad>(model);
        var addedEntity = await unitOfWork.AdRepository.InsertAndGetInserted("InsertAndGetInsertedAdvertisment", adEntity);

        if (model.Images != null && !model.Images.All(x => x.ImageFile.Length == 0))
        {
            var images = mapper.Map<IEnumerable<Image>>((model, addedEntity.Id));
            await InsertAdvertismentsImages(images);
        }
        if (model.Tags != null && model.Tags.Any())
        {
            var tags = mapper.Map<IEnumerable<AdTag>>((model, addedEntity.Id));
            await InsertAdvertismentsTags(tags);
        }

        return await GetByIdAsync(addedEntity.Id);
    }

    public async Task<AdFullInfoDTO> UpdateAsync(Ad model)
    {
        await unitOfWork.AdRepository.UpdateAsync("UpdateAdvertisment", model);
        return await GetByIdAsync(model.Id);
    }

    private async Task InsertAdvertismentsImages(IEnumerable<Image> images)
    => await imageService.InsertRange(images);

    private async Task InsertAdvertismentsTags(IEnumerable<AdTag> tags)
    => await adTagService.InsertRange(tags);
}
