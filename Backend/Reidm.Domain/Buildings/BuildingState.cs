using Reidm.Domain.Buildings.Events;
using Reidm.Domain.Buildings.Values;
using Reidm.Domain.Common;

namespace Reidm.Domain.Buildings;

public class BuildingState : AggregateState
{
	private readonly ValueTracker<IBuildingValue> _valueTracker = new();

	public BuildingState()
	{
		AddHandler<BuildingInfoChanged>(a => _valueTracker.Add(a.Info));
	}

	public bool IsValueChanged(IBuildingValue value) => _valueTracker.HasChanged(value);
}