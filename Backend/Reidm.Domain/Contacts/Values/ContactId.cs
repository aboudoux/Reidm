using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Contacts.Values;

[SerializableTypeIdentifier("27")]
public record ContactId(Guid Value) : IContactValue 
{
	public static ContactId CreateNew() => new(Guid.NewGuid());
}