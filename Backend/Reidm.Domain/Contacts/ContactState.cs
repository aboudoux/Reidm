using Reidm.Domain.Common;
using Reidm.Domain.Contacts.Values;

namespace Reidm.Domain.Contacts;

public class ContactState : AggregateState
{
	private readonly ValueTracker<IContactValue> _valueTracker = new();

	public bool IsValueChanged(IContactValue value) => _valueTracker.HasChanged(value);
}