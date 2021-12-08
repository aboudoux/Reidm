using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("13")]
public record SeparateWaterMeters(bool Value) : IBuildingValue;