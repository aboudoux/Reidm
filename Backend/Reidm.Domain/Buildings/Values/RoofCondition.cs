using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("20")]
public record RoofCondition(int Value) : IBuildingValue;