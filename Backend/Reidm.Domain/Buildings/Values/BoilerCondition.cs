using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("25")]
public record BoilerCondition(int Value) : IBuildingValue;