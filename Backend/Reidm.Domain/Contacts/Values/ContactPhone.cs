using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Contacts.Values;

[SerializableTypeIdentifier("29")]
public record ContactPhone(string Value) : IContactValue;