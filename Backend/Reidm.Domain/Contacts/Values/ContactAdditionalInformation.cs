using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Contacts.Values;

[SerializableTypeIdentifier("37")]
public record ContactAdditionalInformation(string Value) : IContactValue;