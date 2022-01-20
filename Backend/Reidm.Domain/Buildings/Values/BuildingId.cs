using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("33")]
public record BuildingId(Guid Value) : IBuildingValue
{
	public static BuildingId CreateNew() => new(Guid.NewGuid());

}