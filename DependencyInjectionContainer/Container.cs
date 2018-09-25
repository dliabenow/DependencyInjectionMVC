using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DependencyInjectionContainer
{
    public class Container : IContainer
    {
        internal IList<IRegisteredType> RegisteredTypes { get; set; }

        public Container()
        {
            RegisteredTypes = new List<IRegisteredType>();
        }

        #region register

        public IContainer Register<TType, TMapsTo>(LifeCycle lifeCycle = LifeCycle.Transient)
        {
            if (!RegisteredObjectExists<TType, TMapsTo>(lifeCycle))
            {
                RegisteredType newRegistration = new RegisteredType();
                newRegistration.Register<TType, TMapsTo>(null, lifeCycle);

                RegisteredTypes.Add(newRegistration);
            }

            return this;
        }

        public IContainer Register<TType, TMapsTo>(IParameters parameters, LifeCycle lifeCyle = LifeCycle.Transient)
        {
            if (!RegisteredObjectExists<TType, TMapsTo>(lifeCyle))
            {
                RegisteredType newRegistration = new RegisteredType();
                newRegistration.Register<TType, TMapsTo>(parameters, lifeCyle);

                RegisteredTypes.Add(newRegistration);
            }

            return this;
        }

        private bool RegisteredObjectExists<TType, TMapsTo>(LifeCycle lifeCyle)
        {
            return this.RegisteredTypes.Any(
                x => x.TypeName == typeof(TType).FullName
                    && x.MapsToName == typeof(TMapsTo).FullName
                    && x.LifeCycle == lifeCyle
                );
        }

        #endregion

        #region build

        public IContainer Build()
        {
            foreach (var r in RegisteredTypes)
            {
                CreateInstance(r);
            }

            return this;
        }

        #endregion

        #region resolve

        public object CreateInstance(IRegisteredType thisType)
        {
            throw new NotImplementedException();
        }

        public object Resolve<T>(LifeCycle lifecyle)
        {
            var requestedType = RegisteredTypes.Where(x => x.TypeName == typeof(T).FullName && x.LifeCycle == lifecyle).Select(x => x).FirstOrDefault();
            if (requestedType != null)
            {
                if (lifecyle == LifeCycle.Singleton)
                {
                    return requestedType.MapsToInstance;
                }
                else
                {
                    return CreateInstance(requestedType);
                }
            }
            else
            {
                return new Exception(String.Format("The requested Type: {0} has not been registered with this container.", typeof(T)));
            }
        }

        private static ConstructorInfo GetConstructor(IRegisteredType type, IList<object> parameters, Type[] parameterTypes)
        {
            ConstructorInfo constructor = type.MapsTo.GetConstructor(parameterTypes);

            if (constructor == null)
                throw new Exception("Constructor not found");

            return constructor;
        }

        private static Type[] GetParameterTypeArray(IList<object> parameters)
        {
            Type[] parameterTypes = new Type[parameters.Count];
            for (int i = 0; i <= parameters.Count - 1; i++)
            {
                parameterTypes[i] = parameters[i].GetType();
            }
            return parameterTypes;
        }

        private IList<object> GetConstructorParameters(IRegisteredType type)
        {
            IList<object> parameters = new List<object>();

            var constructorParameterCollection = ((IParameters)type.Parameters);

            return parameters;
        }

        #endregion

    }
}
