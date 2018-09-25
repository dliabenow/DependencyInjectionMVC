namespace DependencyInjectionContainer
{
    public interface IContainer
    {
        IContainer Register<TType, TMapsTo>(IParameters parameters, LifeCycle lifeCyle = LifeCycle.Transient);
        IContainer Register<TType, TMapsTo>(LifeCycle lifeCyle = LifeCycle.Transient);

        IContainer Build();

        object Resolve<T>(LifeCycle lifecyle);
    }
}
