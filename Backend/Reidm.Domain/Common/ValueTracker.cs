using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Common;

public class ValueTracker<T> where T : class, ISerializableType {
	private readonly Dictionary<Type, T> _values = new();

	public void Add(T value) {
		var type = value.GetType();
		if (!_values.ContainsKey(type))
			_values.Add(type, null);

		_values[type] = value;
	}

	public bool HasChanged(T value) {
		if (value == null) throw new ArgumentNullException(nameof(value));
		var type = value.GetType();
		if (!_values.ContainsKey(type)) return true;
		return !_values[type].Equals(value);
	}
}