using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("5")]
public record BuildYear(int Value) : IBuildingValue;