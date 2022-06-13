namespace Advertisment.DAL.Enteties;

public class Image
{
    //public Ad Advertisment { get; set; }
    public int Id { get; set; }
    public int AdvertismentId { get; set; }
    public byte[] ImageFile { get; set; }
}
