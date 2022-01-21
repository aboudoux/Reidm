using Reidm.Application.Common;
using Reidm.Application.Contacts.Queries;

namespace Reidm.Application.Contacts;

public class ContactQueryHandler : IQueryHandler<GetAllContacts, ContactResult[]>
{
	private readonly IContactRepository _contactRepository;

	public ContactQueryHandler(IContactRepository contactRepository)
	{
		_contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
	}
	public Task<ContactResult[]> Handle(GetAllContacts query, CancellationToken cancellationToken)
	{
		return Task.FromResult(_contactRepository.GetAllContact());
	}
}