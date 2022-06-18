using Advertisment.BLL.DTO;
using MassTransit;

namespace AdvertismentAPI.Helpers;

public interface IAdPublisher
{
    void Publish(AdDTO adDTO);
}

public class AdPublisher : IAdPublisher
{
    private readonly IBus bus;
    public AdPublisher(IBus bus) => this.bus = bus;

    public void Publish(AdDTO adDTO)
    {
        var adToPublish = ConvertToCommonAdvertisment(adDTO);
        bus.Publish(adToPublish);
    }

    private UAHause.CommonWork.Models.Advertisment ConvertToCommonAdvertisment(AdDTO adDTO)
    {
        return new UAHause.CommonWork.Models.Advertisment
        {
            adExternalId = adDTO.Id,
            OwnerId = adDTO.UserId,
            TitleImage = adDTO.Images.FirstOrDefault()?.ImageFile,
            Price = adDTO.Price,
            RoomNumber = adDTO.RoomNumber,
            FloorAmount = adDTO.FloorAmount,
            Pool = adDTO.Pool,
            Balkon = adDTO.Balkon,
            HouseYear = adDTO.HouseYear,
            RentOportunity = adDTO.RentOportunity,
            Region = adDTO.Region,
            City = adDTO.City,
            AreaOfHouse = adDTO.AreaOfHouse,
        };
    }
}
