using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("15")]
public record Surface(int Value) : IBuildingValue;