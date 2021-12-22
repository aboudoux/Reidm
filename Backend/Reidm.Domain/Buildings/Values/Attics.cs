using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("2")]
public record Attics(bool Value) : IBuildingValue;