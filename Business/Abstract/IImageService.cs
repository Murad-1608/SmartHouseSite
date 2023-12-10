using Entity.Concrete;

namespace Business.Abstract
{
    public interface IImageService
    {
        Task Add(Image image);
        Task<List<Image>> GetImages(string productId);
    }
}
