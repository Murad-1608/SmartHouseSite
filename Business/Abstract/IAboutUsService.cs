using Entity.Concrete;

namespace Business.Abstract
{
    public interface IAboutUsService
    {
        AboutUs GetAbout();
        Task Update(AboutUs aboutUs);
    }
}
