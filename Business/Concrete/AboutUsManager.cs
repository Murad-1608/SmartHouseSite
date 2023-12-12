using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class AboutUsManager : IAboutUsService
    {
        private readonly IAboutUsDal aboutUsDal;
        public AboutUsManager(IAboutUsDal aboutUsDal)
        {
            this.aboutUsDal = aboutUsDal;
        }

        public AboutUs GetAbout()
        {
            var about = aboutUsDal.GetAllAsync().Result.Last();

            return about;
        }

        public async Task Update(AboutUs aboutUs)
        {
            await aboutUsDal.UpdateAsync(aboutUs);
        }
    }
}
