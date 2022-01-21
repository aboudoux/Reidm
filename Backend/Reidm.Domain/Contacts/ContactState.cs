using Reidm.Domain.Common;
using Reidm.Domain.Contacts.Events;
using Reidm.Domain.Contacts.Values;

namespace Reidm.Domain.Contacts;

public class ContactState : AggregateState
{
	private readonly ValueTracker<IContactValue> _valueTracker = new();
	private bool _removed = false;

	public ContactState()
	{
		AddHandler<ContactInfoChanged>(a => _valueTracker.Add(a.Value));
		AddHandler<ContactRemoved>(a => _removed = true);
	}

	public bool IsValueChanged(IContactValue value) => _valueTracker.HasChanged(value);

	public bool CanRemove() => !_removed;
}