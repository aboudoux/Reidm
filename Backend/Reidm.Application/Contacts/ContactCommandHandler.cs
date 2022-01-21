using Reidm.Application.Common;
using Reidm.Application.Contacts.Commands;
using Reidm.Domain.Common.Events;
using Reidm.Domain.Contacts;

namespace Reidm.Application.Contacts;

public class ContactCommandHandler : 
	ICommandHandler<CreateContact>,
	ICommandHandler<ChangeContactInformation>
{
	private readonly IEventBroker _eventBroker;

	public ContactCommandHandler(IEventBroker eventBroker)
	{
		_eventBroker = eventBroker ?? throw new ArgumentNullException(nameof(eventBroker));
	}
	public async Task<CommandResult> Handle(CreateContact command, CancellationToken cancellationToken)
	{
		var newContact = Contact.Add(command.Name);
		if (newContact.UncommittedEvents.IsEmpty)
			return CommandResult.NotApplied();

		await _eventBroker.Publish(newContact.UncommittedEvents);
		return CommandResult.Added(newContact.AggregateId);
	}

	public async Task<CommandResult> Handle(ChangeContactInformation command, CancellationToken cancellationToken)
	{
		var contact = await _eventBroker.GetAggregate<Contact>(command.ContactId.Value);
		contact.ChangeInfo(command.Value);

		if(contact.UncommittedEvents.IsEmpty)
			return CommandResult.NotApplied();

		await _eventBroker.Publish(contact.UncommittedEvents);
		return CommandResult.Ok();
	}
}