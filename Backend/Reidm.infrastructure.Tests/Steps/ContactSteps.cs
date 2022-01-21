using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Reidm.Application.Buildings.Commands;
using Reidm.Application.Contacts.Commands;
using Reidm.Application.Contacts.Queries;
using Reidm.Domain.Common;
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

	[Given(@"Une liste de contacts exitants")]
	public async Task GivenUneListeDeContactsExitants(ContactName[] contacts) 
	{
		await contacts.ForEachAsync(async a => await SendCommand(new CreateContact(a)));
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
			"Infos" => new ContactAdditionalInformation(value),
			"Quality" => value == "Propriétaire" ? new ContactQualityOwner() : new ContactQualityRealEstateAgent()
		};

		await SendCommand(new ChangeContactInformation(new ContactId(selectedContact.ContactId), info));
	}

	[When(@"Je supprime le contact ""([^""]*)""")]
	public async Task WhenJeSupprimeLeContact(ContactName name) 
	{
		var selectedContact = (await Query(new GetAllContacts())).First(a => a.Name == name.Value);
		await SendCommand(new RemoveContact(new ContactId(selectedContact.ContactId)));
	}


	[Then(@"La liste des contacts est")]
	public async Task ThenLaListeDesContactsEst(ContactResult[] contacts)
	{
		var all = await Query(new GetAllContacts());
		all.Should().BeEquivalentTo(contacts, a => a.Excluding(b => b.ContactId));
	}
}