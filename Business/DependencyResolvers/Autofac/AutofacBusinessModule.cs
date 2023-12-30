using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance(); 

            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();

            builder.RegisterType<EfContactDal>().As<IContactDal>().SingleInstance();
            builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();

            builder.RegisterType<EfImageDal>().As<IImageDal>().SingleInstance();
            builder.RegisterType<ImageManager>().As<IImageService>().SingleInstance();

            builder.RegisterType<EfPortfolioDal>().As<IPortfolioDal>().SingleInstance();
            builder.RegisterType<PortfolioManager>().As<IPortfolioService>().SingleInstance();

            builder.RegisterType<EfAboutUsDal>().As<IAboutUsDal>().SingleInstance();
            builder.RegisterType<AboutUsManager>().As<IAboutUsService>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
