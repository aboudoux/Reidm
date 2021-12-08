using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("10")]
public record PropertyTax(int Value) : IBuildingValue;