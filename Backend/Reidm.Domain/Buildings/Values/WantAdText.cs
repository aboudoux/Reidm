using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("24")]
public record WantAdText(string Value) : IBuildingValue;