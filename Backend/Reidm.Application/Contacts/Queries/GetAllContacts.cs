using Reidm.Application.Common;

namespace Reidm.Application.Contacts.Queries {
	public class GetAllContacts : IQuery<ContactResult[]> { }

	public record ContactResult(string ContactId, string Name, string Phone, string Email, string Quality, string AdditionalInfo);
}
