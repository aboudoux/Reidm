using System.Runtime.Serialization;

namespace Reidm.Domain.Common.Exceptions
{
    [Serializable]
    public class AggregateNotFoundException : Exception {
        public AggregateNotFoundException(Type aggregateType)
            : base($"Aggregate {aggregateType.Name} not found.") {
        }

        protected AggregateNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}