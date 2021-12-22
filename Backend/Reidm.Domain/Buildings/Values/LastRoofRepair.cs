using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("21")]
public record LastRoofRepair(DateTime? Value) : IBuildingValue;