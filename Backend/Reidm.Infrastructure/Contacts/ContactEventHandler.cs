using Reidm.Application.Common;
using Reidm.Domain.Common.Events;
using Reidm.Domain.Contacts.Events;
using Reidm.Domain.Contacts.Values;

namespace Reidm.Infrastructure.Contacts;

public class ContactEventHandler : IEventHandler<ContactAdded>
{
	private readonly IContactRepository _repository;

	public ContactEventHandler(IContactRepository repository)
	{
		_repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}
	public Task Handle(ContactAdded @event, CancellationToken cancellationToken)
	{
		_repository.Add(new ContactId(@event.AggregateId), @event.Name);
		return Task.CompletedTask;
	}
}