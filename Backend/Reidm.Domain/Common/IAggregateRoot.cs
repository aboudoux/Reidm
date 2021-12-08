using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Common
{
    public interface IAggregateRoot
    {
        UncommittedEvents UncommittedEvents { get; }
    }
}