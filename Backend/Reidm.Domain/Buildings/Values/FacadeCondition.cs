using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("23")]
public record FacadeCondition(int Value) : IBuildingValue;