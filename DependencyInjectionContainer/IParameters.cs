namespace DependencyInjectionContainer
{
    public interface IParameters
    {
        IParameters Add(object value);
        IParameters Add(RegisteredType value);
    }
}
