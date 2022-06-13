using Advertisment.BLL.DTO;
using Advertisment.DAL.Enteties;
using AutoMapper;

namespace Advertisment.BLL.Convertors;

public class ConvertToImageList : ITypeConverter<(AdCreateDTO, int), IEnumerable<Image>>
{
    public IEnumerable<Image> Convert((AdCreateDTO, int) source, IEnumerable<Image> destination, ResolutionContext context)
    {
        foreach (var image in source.Item1.Images)
        {
            yield return new Image() { AdvertismentId = source.Item2, ImageFile = image.ImageFile };
        }
    }
}

public class ConvertToAdTagList : ITypeConverter<(AdCreateDTO, int), IEnumerable<AdTag>>
{
    public IEnumerable<AdTag> Convert((AdCreateDTO, int) source, IEnumerable<AdTag> destination, ResolutionContext context)
    {
        foreach (var tag in source.Item1.Tags)
        {
            yield return new AdTag() { AdvertismentID = source.Item2, TagName = tag.TagName };
        }
    }
}

public class ConvertToAdDTO : ITypeConverter<(Ad, IEnumerable<Image>, IEnumerable<Tag>), AdDTO>
{
    private readonly IMapper mapper;
    public ConvertToAdDTO(IMapper mapper) => this.mapper = mapper;

    public AdDTO Convert((Ad, IEnumerable<Image>, IEnumerable<Tag>) source, AdDTO destination, ResolutionContext context)
    {
        AdDTO advertisment = mapper.Map<AdDTO>(source.Item1);
        advertisment.Images = source.Item2;
        advertisment.Tags = source.Item3;
        return advertisment;
    }
}
