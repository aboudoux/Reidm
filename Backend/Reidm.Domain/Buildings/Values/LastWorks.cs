using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("9")]
public record LastWorks(string Value) : IBuildingValue;