using System;

namespace DependencyInjectionContainer
{
    public class RegisteredType : IRegisteredType
    {
        public string TypeName { get; set; }
        public Type ThisType { get; set; }
        public string MapsToName { get; set; }
        public Type MapsTo { get; set; }
        public object MapsToInstance { get; set; }
        public LifeCycle LifeCycle { get; set; }
        public IParameters Parameters { get; set; }

        public IRegisteredType Register<TType, TMapsTo>(IParameters parameters, LifeCycle lifeCyle = LifeCycle.Transient)
        {
            this.TypeName = typeof(TType).FullName;
            this.ThisType = typeof(TType);
            this.MapsToName = typeof(TMapsTo).FullName;
            this.MapsTo = typeof(TMapsTo);
            this.LifeCycle = LifeCycle;
            this.Parameters = parameters;

            return this;
        }
    }
}
