using Reidm.Domain.Common.Events;
using Reidm.Domain.Contacts.Values;

namespace Reidm.Domain.Contacts.Events;

[SerializableTypeIdentifier("31")]
public record ContactAdded(ContactName Name) : DomainEvent;