using System.Runtime.Serialization;

namespace Reidm.Domain.Common.Exceptions
{
    [Serializable]
    public class AggregateInstantiationException : Exception {
        public AggregateInstantiationException(Type aggregateType)
            : base($"Cannot instantiate a new aggregate of type {aggregateType.Name}") {
        }

        protected AggregateInstantiationException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}