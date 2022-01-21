using Reidm.Application.Common;
using Reidm.Domain.Common.Events;
using Reidm.Domain.Contacts.Events;
using Reidm.Domain.Contacts.Values;

namespace Reidm.Infrastructure.Contacts;

public class ContactEventHandler : 
	IEventHandler<ContactAdded>,
	IEventHandler<ContactInfoChanged>,
	IEventHandler<ContactRemoved>
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

	public Task Handle(ContactInfoChanged @event, CancellationToken cancellationToken)
	{
		_repository.ChangeValue(new ContactId(@event.AggregateId), @event.Value);
		return Task.CompletedTask;
	}

	public Task Handle(ContactRemoved @event, CancellationToken cancellationToken)
	{
		_repository.Remove(new ContactId(@event.AggregateId));
		return Task.CompletedTask;
	}
}