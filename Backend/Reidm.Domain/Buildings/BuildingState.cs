using Reidm.Domain.Buildings.Events;
using Reidm.Domain.Buildings.Values;
using Reidm.Domain.Common;

namespace Reidm.Domain.Buildings;

public class BuildingState : AggregateState
{
	private readonly BuildingInfoTracker _valueTracker = new();

	public BuildingState()
	{
		AddHandler<BuildingInfoChanged>(a => _valueTracker.Add(a.Info));
	}

	public bool IsValueChanged(IBuildingValue value) => _valueTracker.HasChanged(value);
		

	private class BuildingInfoTracker
	{
		private readonly Dictionary<Type, IBuildingValue> _values = new();

		public void Add(IBuildingValue value)
		{
			var type = value.GetType();
			if (!_values.ContainsKey(type))
				_values.Add(type, null);

			_values[type] = value;
		}

		public bool HasChanged(IBuildingValue value)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			var type = value.GetType();
			if (!_values.ContainsKey(type)) return true;
			return !_values[type].Equals(value);
		}
	}
}