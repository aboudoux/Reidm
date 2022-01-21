using Reidm.Application.Common;
using Reidm.Application.Contacts.Queries;
using Reidm.Domain.Contacts.Values;

namespace Reidm.Infrastructure.Repositories;

public class InMemoryContactRepository : IContactRepository
{
	private Dictionary<ContactId, ContactResult> _contact = new();

	public ContactResult[] GetAllContact()
	{
		return _contact.Values.ToArray();
	}

	public void Add(ContactId contactId, ContactName name)
	{
		_contact.Add(contactId, new ContactResult(contactId.Value,name.Value, string.Empty, string.Empty));
	}
}