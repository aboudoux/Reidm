using Reidm.Domain.Common;
using Reidm.Domain.Common.Events;
using Reidm.Domain.Contacts.Events;
using Reidm.Domain.Contacts.Values;

namespace Reidm.Domain.Contacts;

public class Contact : AggregateRoot<ContactState> 
{
	public Contact(History history) : base(history)
	{
	}

	public static Contact Add(ContactName name)
		=> CreateNew<Contact>(ContactId.CreateNew().Value.ToString(), new ContactAdded(name));

	public void ChangeInfo(IContactValue contactValue) {
		if (State.IsValueChanged(contactValue))
			RaiseEvent(new ContactInfoChanged(contactValue));
	}
}

public class ContactState : AggregateState
{
	private readonly ValueTracker<IContactValue> _valueTracker = new();

	public bool IsValueChanged(IContactValue value) => _valueTracker.HasChanged(value);
}