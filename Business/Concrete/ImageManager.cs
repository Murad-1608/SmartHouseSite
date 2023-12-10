using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly IImageDal imageDal;
        public ImageManager(IImageDal imageDal)
        {
            this.imageDal = imageDal;
        }

        public async Task Add(Image image)
        {
            await imageDal.AddAsync(image);
        }

        public Task<List<Image>> GetImages(string productId)
        {
            return imageDal.GetAllAsync(x => x.ProductId.ToString() == productId);
        }
    }
}
