using Business.Constants;
using Core.Extensions;
using Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Interceptors;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac;

public class SecuredOperations : MethodInterception
{
    private string[] _roles;
    private IHttpContextAccessor _httpContextAccessor;

    public SecuredOperations(string roles)
    {
        _roles = roles.Split(',');
        _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
    }

    protected override void OnBefore(IInvocation invocation)
    {
        var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
        foreach (var role in _roles)
        {
            if (roleClaims.Contains(role))
            {
                return;
            }
        }
        throw new Exception(Messages.AuthorizationDenied);
    }
}