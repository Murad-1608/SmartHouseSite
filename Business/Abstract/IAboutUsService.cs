using Entity.Concrete;

namespace Business.Abstract
{
    public interface IAboutUsService
    {
        Task<AboutUs> GetAbout();
        
    }
}
