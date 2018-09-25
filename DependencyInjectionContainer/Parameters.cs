using System.Collections.Generic;

namespace DependencyInjectionContainer
{
    public class Parameters : IParameters
    {
        internal IList<object> ParametersCollection { get; set; }

        protected Parameters()
        {
            this.ParametersCollection = new List<object>();
        }

        public IParameters Add(object value)
        {
            ParametersCollection.Add(value);
            return this;
        }

        public IParameters Add(RegisteredType value)
        {
            ParametersCollection.Add(value);
            return this;
        }
    }
}
