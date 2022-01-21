using Reidm.Application.Common;
using Reidm.Application.Contacts.Queries;
using Reidm.Domain.Contacts.Values;

namespace Reidm.Infrastructure.Repositories;

public class InMemoryContactRepository : IContactRepository
{
	private readonly Dictionary<ContactId, ContactResult> _contact = new();

	public ContactResult[] GetAllContact()
	{
		return _contact.Values.ToArray();
	}

	public void Add(ContactId contactId, ContactName name)
	{
		_contact.Add(contactId, new ContactResult(contactId.Value, name.Value, string.Empty, string.Empty));
	}

	public void ChangeValue(ContactId contactId, IContactValue value)
	{
		if (!_contact.ContainsKey(contactId)) throw new ArgumentNullException($"Contact {contactId.Value} not found");
		_contact[contactId] = value switch
		{
			ContactPhone i => _contact[contactId] with {Phone = i.Value},
			ContactEmail i => _contact[contactId] with {Email = i.Value},
			ContactName i => _contact[contactId] with {Name = i.Value},
			_ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
		};
	}

	public void Remove(ContactId contactId)
	{
		_contact.Remove(contactId);
	}
}