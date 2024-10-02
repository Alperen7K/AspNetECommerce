using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors;

public abstract partial class MethodInterceptionBaseAttribute : Attribute, IInterceptor
{
    public int Priorty { get; set; }


    public virtual void Intercept(IInvocation invocation)
    {
    }
}