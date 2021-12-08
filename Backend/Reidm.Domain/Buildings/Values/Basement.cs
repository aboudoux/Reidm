using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("3")]
public record Basement(bool Value) : IBuildingValue;