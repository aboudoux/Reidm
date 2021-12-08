using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("16")]
public record TownGas(bool Value) : IBuildingValue;