using Reidm.Domain.Common.Events;
namespace Reidm.Domain.Buildings.Events;


[SerializableTypeIdentifier("26")]
public record ContactMade(ContactName Name, ContactPhone Phone, ContactEmail Email) : DomainEvent;

public record ContactName(string Value);

public record ContactPhone(string Value);

public record ContactEmail(string Value);
