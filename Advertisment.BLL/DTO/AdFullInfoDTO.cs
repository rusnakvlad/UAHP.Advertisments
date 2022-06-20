using Advertisment.DAL.Enteties;

namespace Advertisment.BLL.DTO;
public class AdFullInfoDTO
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string OwnerName { get; set; }
    public string OwnerSurname { get; set; }
    public string OwnerEmail { get; set; }
    public string OwnerPhone { get; set; }
    public int Price { get; set; }
    public string Region { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string HouseType { get; set; }
    public int AreaOfHouse { get; set; }
    public int FloorAmount { get; set; }
    public int RoomNumber { get; set; }
    public int HouseYear { get; set; }
    public bool Pool { get; set; }
    public bool Balkon { get; set; }
    public bool RentOportunity { get; set; }
    public string Description { get; set; }
    public IEnumerable<Image> Images { get; set; }
    public IEnumerable<Tag> Tags { get; set; }
}
