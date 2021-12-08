using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings.Values;

[SerializableTypeIdentifier("14")]
public record SewageServices(bool Value) : IBuildingValue;