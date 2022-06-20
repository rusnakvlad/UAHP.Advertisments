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

public class ConvertToAdFullInfoDTO : ITypeConverter<(Ad, IEnumerable<Image>, IEnumerable<Tag>), AdFullInfoDTO>
{
    private readonly IMapper mapper;
    public ConvertToAdFullInfoDTO(IMapper mapper) => this.mapper = mapper;

    public AdFullInfoDTO Convert((Ad, IEnumerable<Image>, IEnumerable<Tag>) source, AdFullInfoDTO destination, ResolutionContext context)
    {
        AdFullInfoDTO advertisment = mapper.Map<AdFullInfoDTO>(source.Item1);
        advertisment.Images = source.Item2;
        advertisment.Tags = source.Item3;
        return advertisment;
    }
}
