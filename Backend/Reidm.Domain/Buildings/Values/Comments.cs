using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("8")]
public record Comments(string Value) : IBuildingValue;