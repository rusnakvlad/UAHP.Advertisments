using Advertisment.DAL.Enteties;

namespace Advertisment.BLL.IServices;

public interface IImageService
{
    public Task InsertImageAsync(Image image);
    public Task<IEnumerable<Image>> GetImagesByAdId(int advertismentId);
    public Task InsertRange(IEnumerable<Image> images);
    public Task DeleteById(int Id);
}
