using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("33")]
public record BuildingId(string Value) : IBuildingValue
{
	public static BuildingId CreateNew() => new(Guid.NewGuid().ToString());

}