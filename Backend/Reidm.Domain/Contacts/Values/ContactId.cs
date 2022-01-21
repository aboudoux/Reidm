using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Contacts.Values;

[SerializableTypeIdentifier("27")]
public record ContactId(string Value) : IContactValue 
{
	public static ContactId CreateNew() => new(Guid.NewGuid().ToString());
}