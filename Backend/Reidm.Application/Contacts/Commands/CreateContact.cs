using Reidm.Application.Common;
using Reidm.Domain.Contacts.Values;

namespace Reidm.Application.Contacts.Commands {
	public record CreateContact(ContactName Name) : ICommand;
}
