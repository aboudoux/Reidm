using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Reidm.Application.Contacts.Commands;
using Reidm.Application.Contacts.Queries;
using Reidm.Domain.Contacts.Values;
using TechTalk.SpecFlow;

namespace Reidm.infrastructure.Tests.Steps;

[Binding]
public class ContactSteps : StepBase
{
	[Given(@"Aucun contact n'est visible dans l'application")]
	public async Task GivenAucunContactNapplication()
	{
		(await Query(new GetAllContacts())).Should().BeEmpty("Il y a des contacts a étudier en base");
	}

	[Given(@"J'ajoute un nouveau contact du nom de ""([^""]*)""")]
	[When(@"J'ajoute un nouveau contact du nom de ""([^""]*)""")]
	public async Task WhenJajouteUnNouveauContactDuNomDe(ContactName name)
	{
		await SendCommand(new CreateContact(name));
	}

	[When(@"Je modifie la valeur ""([^""]*)"" du contact ""([^""]*)"" en ""([^""]*)""")]
	public async Task WhenJeModifieLaValeurDuContactEn(string valueName, ContactName name, string value)
	{
		var selectedContact = (await Query(new GetAllContacts())).First(a => a.Name == name.Value);

		var info = valueName switch
		{
			"Phone" => new ContactPhone(value) as IContactValue,
			"Email" => new ContactEmail(value),
			"Name" => new ContactName(value),
		};

		await SendCommand(new ChangeContactInformation(new ContactId(selectedContact.ContactId), info));
	}


	[Then(@"La liste des contacts est")]
	public async Task ThenLaListeDesContactsEst(ContactResult[] contacts)
	{
		(await Query(new GetAllContacts())).Should().BeEquivalentTo(contacts, a => a.Excluding(b => b.ContactId));
	}
}