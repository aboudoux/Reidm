using Reidm.Domain.Buildings.Values;
using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Events;

[SerializableTypeIdentifier("19")]
public record BuildingInfoChanged(IBuildingValue Info) : DomainEvent;