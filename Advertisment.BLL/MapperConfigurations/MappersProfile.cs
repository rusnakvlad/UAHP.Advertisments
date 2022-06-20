using Advertisment.BLL.Convertors;
using Advertisment.BLL.DTO;
using Advertisment.DAL.Enteties;
using AutoMapper;

namespace Advertisment.BLL.MapperConfigurations;

internal class MappersProfile : Profile
{
    public MappersProfile()
    {
        CreateMap<AdCreateDTO, Ad>();
        CreateMap<Ad, AdDTO>();
        CreateMap<Ad, AdFullInfoDTO>();
        CreateMap<(AdCreateDTO advertisment, int advertismentId), IEnumerable<Image>>()
            .ConvertUsing<ConvertToImageList>();
        CreateMap<(AdCreateDTO advertisment, int advertismentId), IEnumerable<AdTag>>()
            .ConvertUsing<ConvertToAdTagList>();
        CreateMap<(Ad, IEnumerable<Image>, IEnumerable<Tag>), AdFullInfoDTO>()
            .ConvertUsing<ConvertToAdFullInfoDTO>();
    }
}
