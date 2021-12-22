using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("11")]
public record SellingPrice(int Value) : IBuildingValue;