using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("6")]
public record Cellar(bool Value) : IBuildingValue;