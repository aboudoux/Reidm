using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("4")]
public record BuildingLabel(string Value) : IBuildingValue
{
	public static implicit operator BuildingLabel(string source) => new(source);
}