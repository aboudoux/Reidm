using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Contacts.Values;

[SerializableTypeIdentifier("30")]
public record ContactEmail(string Value) : IContactValue;