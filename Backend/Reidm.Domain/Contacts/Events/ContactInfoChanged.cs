using Reidm.Domain.Common.Events;
using Reidm.Domain.Contacts.Values;

namespace Reidm.Domain.Contacts.Events;

[SerializableTypeIdentifier("32")]
public record ContactInfoChanged(IContactValue Value) : DomainEvent;