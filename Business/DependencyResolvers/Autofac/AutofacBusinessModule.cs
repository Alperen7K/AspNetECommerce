using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Autofac.Extras.DynamicProxy;
using Core.Utilities.Security.Jwt;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<EfUserDal>().As<IUserDal>();

        builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();

        builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

        builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

        builder.RegisterType<AuthManager>().As<IAuthService>();

        builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();

        builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();

        builder.RegisterType<CategoryManager>().As<ICategoryService>();

        builder.RegisterType<JwtHelper>().As<ITokenHelper>();

        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
    }
}