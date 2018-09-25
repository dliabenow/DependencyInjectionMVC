using System;

namespace DependencyInjectionContainer
{
    public interface IRegisteredType
    {
        string TypeName { get; set; }
        Type ThisType { get; set; }
        string MapsToName { get; set; }
        Type MapsTo { get; set; }
        Object MapsToInstance { get; set; }
        LifeCycle LifeCycle { get; set; }
        IParameters Parameters { get; set; }
    }
}
