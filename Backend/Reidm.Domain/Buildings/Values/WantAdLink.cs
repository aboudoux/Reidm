using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("17")]
public record WantAdLink(string Value) : IBuildingValue;