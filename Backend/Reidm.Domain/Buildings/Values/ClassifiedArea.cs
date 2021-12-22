using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("7")]
public record ClassifiedArea(bool Value) : IBuildingValue;