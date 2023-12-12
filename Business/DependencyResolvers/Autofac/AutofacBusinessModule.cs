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
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<ProductManager>().As<IProductService>();

            builder.RegisterType<EfContactDal>().As<IContactDal>();
            builder.RegisterType<ContactManager>().As<IContactService>();

            builder.RegisterType<EfImageDal>().As<IImageDal>();
            builder.RegisterType<ImageManager>().As<IImageService>();

            builder.RegisterType<EfPortfolioDal>().As<IPortfolioDal>();
            builder.RegisterType<PortfolioManager>().As<IPortfolioService>();

            builder.RegisterType<EfAboutUsDal>().As<IAboutUsDal>();
            builder.RegisterType<AboutUsManager>().As<IAboutUsService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
