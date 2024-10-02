using System.Reflection;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors;

public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();

        var methodAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToArray();

        classAttributes.AddRange(methodAttributes);

        return classAttributes.OrderBy(x => x.Priorty).ToArray();
    }
}