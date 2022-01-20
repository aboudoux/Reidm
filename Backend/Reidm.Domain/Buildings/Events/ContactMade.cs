using Reidm.Domain.Common.Events;
using Reidm.Domain.Contacts;
using Reidm.Domain.Contacts.Values;

namespace Reidm.Domain.Buildings.Events;


[SerializableTypeIdentifier("26")]
public record ContactMade(ContactId Contact) : DomainEvent;