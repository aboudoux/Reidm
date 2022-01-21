using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Contacts.Events;

[SerializableTypeIdentifier("34")]
public record ContactRemoved : DomainEvent;