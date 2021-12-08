using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("12")]
public record SeparateElectricMeters(bool Value) : IBuildingValue;