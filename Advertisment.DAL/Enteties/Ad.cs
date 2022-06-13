namespace Advertisment.DAL.Enteties;

public class Ad // Advertisment
{
    //public User User { get; set; }
    //public IEnumerable<Image> Images { get; set; }
    //public IEnumerable<Tag> Tags { get; set; }

    public int Id { get; set; }
    public string UserId { get; set; }
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
}
