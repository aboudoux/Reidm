using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("22")]
public record LastFacadeRepair(DateTime? Value) : IBuildingValue;